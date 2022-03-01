using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02004418 RID: 17432
public class Mechanism86 : BeMechanism
{
	// Token: 0x06018357 RID: 99159 RVA: 0x00789AD8 File Offset: 0x00787ED8
	public Mechanism86(int id, int lv) : base(id, lv)
	{
	}

	// Token: 0x06018358 RID: 99160 RVA: 0x00789B18 File Offset: 0x00787F18
	public override void OnInit()
	{
		base.OnInit();
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.delayRunTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.delayWaitTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.actionSpeed = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06018359 RID: 99161 RVA: 0x00789BCB File Offset: 0x00787FCB
	public override void OnStart()
	{
		base.OnStart();
		this.handle = base.owner.RegisterEvent(BeEventType.OnAddBuffToOthers, delegate(object[] args)
		{
			this.target = (args[0] as BeActor);
			BeBuff beBuff = args[1] as BeBuff;
			if (beBuff != null && beBuff.buffType == BuffType.STUN && this.target != null && this.target.isMainActor)
			{
				base.owner.CurrentBeScene.FindMonsterByID(this.monsterList, this.monsterID, true);
				this.monsterList.RemoveAll((BeActor x) => x.GetPID() == base.owner.GetPID() || x.IsDead());
				this.readyFlag.Clear();
				this.index = 0;
				this.tmpPos = this.target.GetPosition();
				for (int i = 0; i < this.monsterList.Count; i++)
				{
					this.DoWork(this.monsterList[i]);
				}
			}
		});
	}

	// Token: 0x0601835A RID: 99162 RVA: 0x00789BF4 File Offset: 0x00787FF4
	private void DoWork(BeActor monster)
	{
		if (monster == null || monster.IsDead())
		{
			return;
		}
		monster.aiManager.StopCurrentCommand();
		monster.aiManager.Stop();
		if (monster.IsCastingSkill())
		{
			monster.CancelSkill(monster.GetCurSkillID(), true);
			monster.Locomote(new BeStateData(0, 0), true);
		}
		monster.m_pkGeActor.ShowHeadDialog(TR.Value("monsterSpeech"), false, false, false, false, (float)this.delayWaitTime / 1000f, false);
		monster.delayCaller.DelayCall(this.delayWaitTime + this.index * this.delayRunTime, delegate
		{
			if (monster != null && this.target != null && !monster.IsDead() && !monster.IsInPassiveState() && this.CanRunState(monster))
			{
				this.readyFlag[monster.GetPID()] = false;
				monster.ClearMoveSpeed(7);
				VInt3 vint = (this.tmpPos - monster.GetPosition()).NormalizeTo(this.speed * IntMath.Float2IntWithFixed(1f, 10000L, 100L, MidpointRounding.ToEven));
				monster.SetMoveSpeedX(vint.x);
				monster.SetMoveSpeedY(vint.y);
				monster.SetFace(vint.x < 0, false, false);
				monster.m_pkGeActor.ChangeAction("Anim_Walk", (float)this.actionSpeed / 1000f, true, true, false);
			}
			else
			{
				this.SetMonsterState(monster, true);
			}
		}, 0, 0, false);
		this.index++;
	}

	// Token: 0x0601835B RID: 99163 RVA: 0x00789CF9 File Offset: 0x007880F9
	private bool CanRunState(BeActor monster)
	{
		return monster.sgGetCurrentState() == 0 || monster.sgGetCurrentState() == 2 || monster.sgGetCurrentState() == 3;
	}

	// Token: 0x0601835C RID: 99164 RVA: 0x00789D20 File Offset: 0x00788120
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.monsterList == null)
		{
			return;
		}
		for (int i = 0; i < this.monsterList.Count; i++)
		{
			if (!this.monsterList[i].IsDead())
			{
				if (this.readyFlag.ContainsKey(this.monsterList[i].GetPID()))
				{
					if (!this.readyFlag[this.monsterList[i].GetPID()])
					{
						if (this.monsterList[i].IsInPassiveState())
						{
							this.SetMonsterState(this.monsterList[i], true);
						}
						else if (this.IsNearTargetPosition(this.monsterList[i]))
						{
							this.SetMonsterState(this.monsterList[i], false);
						}
					}
				}
			}
		}
	}

	// Token: 0x0601835D RID: 99165 RVA: 0x00789E1C File Offset: 0x0078821C
	private void SetMonsterState(BeActor monster, bool isBreak = false)
	{
		this.readyFlag[monster.GetPID()] = true;
		monster.aiManager.Start();
		monster.ChangeRunMode(false);
		monster.m_pkGeActor.ChangeAction("Anim_Idle", 0.25f, false, true, false);
		if (isBreak)
		{
			return;
		}
		if (monster.CanUseSkill(this.skillID))
		{
			monster.UseSkill(this.skillID, false);
		}
	}

	// Token: 0x0601835E RID: 99166 RVA: 0x00789E8C File Offset: 0x0078828C
	public override void OnFinish()
	{
		this.target = null;
		this.readyFlag.Clear();
		if (this.monsterList != null)
		{
			this.monsterList.Clear();
			this.monsterList = null;
		}
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x0601835F RID: 99167 RVA: 0x00789EE8 File Offset: 0x007882E8
	public bool IsNearTargetPosition(BeActor monster)
	{
		int num = VInt.Float2VIntValue(1f);
		VInt3 position = monster.GetPosition();
		return Mathf.Abs(this.tmpPos.x - position.x) <= num && Mathf.Abs(this.tmpPos.y - position.y) <= num;
	}

	// Token: 0x04011796 RID: 71574
	private BeEventHandle handle;

	// Token: 0x04011797 RID: 71575
	private BeActor target;

	// Token: 0x04011798 RID: 71576
	private int index;

	// Token: 0x04011799 RID: 71577
	private int skillID;

	// Token: 0x0401179A RID: 71578
	private int delayRunTime;

	// Token: 0x0401179B RID: 71579
	private int delayWaitTime;

	// Token: 0x0401179C RID: 71580
	private int actionSpeed = 250;

	// Token: 0x0401179D RID: 71581
	private int monsterID = 30000021;

	// Token: 0x0401179E RID: 71582
	private VInt3 tmpPos;

	// Token: 0x0401179F RID: 71583
	private List<BeActor> monsterList = new List<BeActor>();

	// Token: 0x040117A0 RID: 71584
	private int speed = 10;

	// Token: 0x040117A1 RID: 71585
	private Dictionary<int, bool> readyFlag = new Dictionary<int, bool>();
}
