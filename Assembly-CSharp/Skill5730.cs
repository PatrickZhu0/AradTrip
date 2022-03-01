using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x020044F6 RID: 17654
internal class Skill5730 : BeSkill
{
	// Token: 0x06018909 RID: 100617 RVA: 0x007ABEF8 File Offset: 0x007AA2F8
	public Skill5730(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601890A RID: 100618 RVA: 0x007ABF56 File Offset: 0x007AA356
	public override void OnInit()
	{
	}

	// Token: 0x0601890B RID: 100619 RVA: 0x007ABF58 File Offset: 0x007AA358
	public override void OnStart()
	{
		base.owner.buffController.TryAddBuff(38, GlobalLogic.VALUE_20000, 1);
		this.deathCount = 0;
	}

	// Token: 0x0601890C RID: 100620 RVA: 0x007ABF7C File Offset: 0x007AA37C
	public override void OnEnterPhase(int phase)
	{
		if (base.owner == null)
		{
			return;
		}
		if (phase == 1)
		{
			base.owner.aiManager.StopCurrentCommand();
			base.owner.aiManager.Stop();
			base.owner.ChangeRunMode(true);
			base.owner.ClearMoveSpeed(7);
			VInt3 vint = base.owner.CurrentBeScene.GetSceneCenterPosition() - base.owner.GetPosition();
			this.timer = vint.magnitude * GlobalLogic.VALUE_1000 / this.speed;
			vint.NormalizeTo(this.speed);
			base.owner.SetMoveSpeedX(vint.x);
			base.owner.SetMoveSpeedY(vint.y);
			base.owner.SetFace(vint.x < 0, false, false);
		}
		else if (phase == 2)
		{
			this.SummonGoblin();
		}
		else if (phase == 3)
		{
			this.CheckResult();
		}
	}

	// Token: 0x0601890D RID: 100621 RVA: 0x007AC088 File Offset: 0x007AA488
	private VInt3[] GetPoints()
	{
		VInt3[] array = new VInt3[this.summonCount];
		VInt vint = VInt.NewVInt(GlobalLogic.VALUE_2000, GlobalLogic.VALUE_1000);
		VInt3 position = base.owner.GetPosition();
		position.x -= vint.i;
		position.y -= vint.i / 2;
		for (int i = 0; i < this.summonCount; i++)
		{
			array[i].x = position.x + vint.i * (i % (this.summonCount / 2));
			array[i].y = position.y + vint.i * (i / (this.summonCount / 2));
		}
		return array;
	}

	// Token: 0x0601890E RID: 100622 RVA: 0x007AC150 File Offset: 0x007AA550
	private void SummonGoblin()
	{
		VInt3[] points = this.GetPoints();
		for (int i = 0; i < this.summonCount; i++)
		{
			Skill5730.<SummonGoblin>c__AnonStorey0 <SummonGoblin>c__AnonStorey = new Skill5730.<SummonGoblin>c__AnonStorey0();
			<SummonGoblin>c__AnonStorey.$this = this;
			<SummonGoblin>c__AnonStorey.point = points[i];
			base.owner.delayCaller.DelayCall(i * 30, delegate
			{
				object[] array = new object[1];
				if (<SummonGoblin>c__AnonStorey.$this.owner.DoSummon(<SummonGoblin>c__AnonStorey.$this.monsterId, <SummonGoblin>c__AnonStorey.$this.level, EffectTable.eSummonPosType.ORIGIN, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, array, true) && array[0] != null)
				{
					BeActor monster = (BeActor)array[0];
					monster.SetPosition(<SummonGoblin>c__AnonStorey.point, false, true, false);
					BeEventHandle item = monster.RegisterEvent(BeEventType.onHit, delegate(object[] args)
					{
						<SummonGoblin>c__AnonStorey.hitMonster = monster;
					});
					<SummonGoblin>c__AnonStorey.$this.handleList.Add(item);
					BeEventHandle item2 = monster.RegisterEvent(BeEventType.onDead, delegate(object[] args)
					{
						if (monster == <SummonGoblin>c__AnonStorey.hitMonster)
						{
							<SummonGoblin>c__AnonStorey.hitMonster = null;
						}
						<SummonGoblin>c__AnonStorey.deathCount++;
						if (<SummonGoblin>c__AnonStorey.deathCount >= <SummonGoblin>c__AnonStorey.summonCount)
						{
							((BeActorStateGraph)<SummonGoblin>c__AnonStorey.owner.GetStateGraph()).ExecuteNextPhaseSkill();
						}
					});
					<SummonGoblin>c__AnonStorey.$this.handleList.Add(item2);
					<SummonGoblin>c__AnonStorey.$this.monsterList.Add(monster);
				}
			}, 0, 0, false);
		}
	}

	// Token: 0x0601890F RID: 100623 RVA: 0x007AC1C0 File Offset: 0x007AA5C0
	private void CheckResult()
	{
		this.result = false;
		for (int i = 0; i < this.monsterList.Count; i++)
		{
			if (this.monsterList[i] != null && !this.monsterList[i].IsDead())
			{
				this.result = true;
				BeActor monster = this.monsterList[i];
				monster.UseSkill(this.skillId, true);
				monster.delayCaller.DelayCall(GlobalLogic.VALUE_3000, delegate
				{
					if (monster == this.hitMonster)
					{
						monster.m_pkGeActor.SetHPDamage(int.MaxValue, HitTextType.NORMAL);
					}
					monster.GetEntityData().SetHP(-1);
					monster.DoDead(false);
				}, 0, 0, false);
			}
		}
		this.monsterList.Clear();
		if (this.result)
		{
			base.owner.buffController.TryAddBuff(this.buffId, GlobalLogic.VALUE_2000, 1);
		}
	}

	// Token: 0x06018910 RID: 100624 RVA: 0x007AC2A8 File Offset: 0x007AA6A8
	public override void OnUpdate(int iDeltime)
	{
		if (base.owner == null)
		{
			return;
		}
		if (this.curPhase == 1)
		{
			this.timer -= iDeltime;
			if (this.timer <= 0)
			{
				base.owner.m_pkGeActor.ChangeAction("Anim_Idle", 0.25f, false, true, false);
				base.owner.ResetMoveCmd();
				base.owner.aiManager.Start();
				base.owner.ChangeRunMode(false);
				((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
			}
		}
		else if (this.curPhase == 3 && !this.result)
		{
			((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
		}
		else if (this.curPhase == 4 && this.result)
		{
			((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
		}
	}

	// Token: 0x06018911 RID: 100625 RVA: 0x007AC3A3 File Offset: 0x007AA7A3
	public override void OnCancel()
	{
		this.Release();
	}

	// Token: 0x06018912 RID: 100626 RVA: 0x007AC3AB File Offset: 0x007AA7AB
	public override void OnFinish()
	{
		this.Release();
	}

	// Token: 0x06018913 RID: 100627 RVA: 0x007AC3B4 File Offset: 0x007AA7B4
	private void Release()
	{
		this.hitMonster = null;
		this.monsterList.Clear();
		this.RemoveBuff();
		for (int i = 0; i < this.handleList.Count; i++)
		{
			this.handleList[i].Remove();
			this.handleList[i] = null;
		}
		this.handleList.Clear();
	}

	// Token: 0x06018914 RID: 100628 RVA: 0x007AC420 File Offset: 0x007AA820
	private void RemoveBuff()
	{
		BeBuff beBuff = base.owner.buffController.HasBuffByID(36);
		if (beBuff != null)
		{
			base.owner.buffController.RemoveBuff(beBuff);
		}
	}

	// Token: 0x04011B92 RID: 72594
	private int monsterId = 30010011;

	// Token: 0x04011B93 RID: 72595
	private int buffId = 521344;

	// Token: 0x04011B94 RID: 72596
	private int skillId = 5678;

	// Token: 0x04011B95 RID: 72597
	private int summonCount = 6;

	// Token: 0x04011B96 RID: 72598
	private int speed = 40000;

	// Token: 0x04011B97 RID: 72599
	private int timer;

	// Token: 0x04011B98 RID: 72600
	private int deathCount;

	// Token: 0x04011B99 RID: 72601
	private bool result;

	// Token: 0x04011B9A RID: 72602
	private List<BeActor> monsterList = new List<BeActor>();

	// Token: 0x04011B9B RID: 72603
	private List<BeEventHandle> handleList = new List<BeEventHandle>();

	// Token: 0x04011B9C RID: 72604
	private BeActor hitMonster;
}
