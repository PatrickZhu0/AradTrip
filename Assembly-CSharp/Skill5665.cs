using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020044F0 RID: 17648
public class Skill5665 : BeSkill
{
	// Token: 0x060188DF RID: 100575 RVA: 0x007AAAF0 File Offset: 0x007A8EF0
	public Skill5665(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060188E0 RID: 100576 RVA: 0x007AAB54 File Offset: 0x007A8F54
	public override void OnInit()
	{
		if (this.skillData != null)
		{
			this.monsterId = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
			this.skillId = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
			this.skillCount = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
			this.skillCd = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
			if (this.skillData.ValueE.Count > 0)
			{
				this.unitDis = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true), GlobalLogic.VALUE_1000).i;
			}
			if (this.skillData.ValueF.Count > 0)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueF[0], base.level, true);
				this.speed = valueFromUnionCell * 10000 / GlobalLogic.VALUE_1000;
			}
			if (this.skillData.ValueG.Count > 0)
			{
				this.useSkillNumber = TableManager.GetValueFromUnionCell(this.skillData.ValueG[0], base.level, true);
			}
		}
	}

	// Token: 0x060188E1 RID: 100577 RVA: 0x007AACC3 File Offset: 0x007A90C3
	public override void OnStart()
	{
		this.DoWork();
		this.timer = this.skillCd;
		this.count = 0;
	}

	// Token: 0x060188E2 RID: 100578 RVA: 0x007AACE0 File Offset: 0x007A90E0
	private List<VInt3> GetPoints(int pointCount)
	{
		List<VInt3> list = new List<VInt3>();
		if (pointCount == 0)
		{
			return list;
		}
		VInt3 vint = base.owner.GetPosition();
		vint.x += ((!base.owner.GetFace()) ? -10000 : 10000);
		vint = BeAIManager.FindStandPosition(vint, base.owner.CurrentBeScene, base.owner.GetFace(), false, 12);
		if (base.owner.CurrentBeScene.IsInBlockPlayer(vint))
		{
			vint = base.owner.GetPosition();
			if (base.owner.CurrentBeScene.IsInBlockPlayer(vint))
			{
				for (int i = 0; i < pointCount; i++)
				{
					list.Add(vint);
				}
				return list;
			}
		}
		if (pointCount == 1)
		{
			list.Add(vint);
			return list;
		}
		int num = 100;
		VInt3 vint2 = vint;
		for (int j = 0; j < num; j++)
		{
			VInt3 vint3 = vint2;
			vint3.y += GlobalLogic.VALUE_1000;
			if (base.owner.CurrentBeScene.IsInBlockPlayer(vint3))
			{
				break;
			}
			vint2 = vint3;
		}
		if (vint2 != vint)
		{
			vint2.y -= GlobalLogic.VALUE_500;
		}
		VInt3 vint4 = vint;
		for (int k = 0; k < num; k++)
		{
			VInt3 vint5 = vint4;
			vint5.y -= GlobalLogic.VALUE_1000;
			if (base.owner.CurrentBeScene.IsInBlockPlayer(vint5))
			{
				break;
			}
			vint4 = vint5;
		}
		if (vint4 != vint)
		{
			vint4.y += GlobalLogic.VALUE_500;
		}
		int num2 = vint2.y - vint4.y;
		int num3 = num2 / (pointCount - 1);
		if (num3 <= this.unitDis)
		{
			for (int l = 0; l < pointCount; l++)
			{
				VInt3 item = vint4;
				item.y += num3 * l;
				list.Add(item);
			}
		}
		else
		{
			int num4 = this.unitDis * (pointCount - 1) / 2;
			VInt3 position = vint;
			position.y += num4;
			VInt3 vint6 = vint;
			vint6.y -= num4;
			if (!base.owner.CurrentBeScene.IsInBlockPlayer(position) && !base.owner.CurrentBeScene.IsInBlockPlayer(vint6))
			{
				for (int m = 0; m < pointCount; m++)
				{
					VInt3 item2 = vint6;
					item2.y += this.unitDis * m;
					list.Add(item2);
				}
			}
			else if (base.owner.CurrentBeScene.IsInBlockPlayer(position))
			{
				for (int n = 0; n < pointCount; n++)
				{
					VInt3 item3 = vint2;
					item3.y -= this.unitDis * n;
					list.Add(item3);
				}
			}
			else
			{
				for (int num5 = 0; num5 < pointCount; num5++)
				{
					VInt3 item4 = vint4;
					item4.y += this.unitDis * num5;
					list.Add(item4);
				}
			}
		}
		return list;
	}

	// Token: 0x060188E3 RID: 100579 RVA: 0x007AB034 File Offset: 0x007A9434
	private void MonstersUseSkill()
	{
		int num = this.monsters.Count;
		if (this.useSkillNumber > 0)
		{
			num = Mathf.Min(this.useSkillNumber, this.monsters.Count);
			if (this.monsters.Count > 1)
			{
				int num2 = this.monsters.Count * 2;
				for (int i = 0; i < num2; i++)
				{
					int index = base.FrameRandom.InRange(1, this.monsters.Count);
					BeActor value = this.monsters[0];
					this.monsters[0] = this.monsters[index];
					this.monsters[index] = value;
				}
			}
		}
		for (int j = 0; j < num; j++)
		{
			BeActor beActor = this.monsters[j];
			if (beActor != null && !beActor.IsDead() && !beActor.IsInPassiveState())
			{
				beActor.UseSkill(this.skillId, true);
			}
		}
	}

	// Token: 0x060188E4 RID: 100580 RVA: 0x007AB140 File Offset: 0x007A9540
	private void DoWork()
	{
		base.owner.buffController.TryAddBuff(1, GlobalLogic.VALUE_20000, 1);
		this.monsters.Clear();
		this.points.Clear();
		this.startPoints.Clear();
		this.moveDistance.Clear();
		this.readyFlags.Clear();
		base.owner.CurrentBeScene.FindMonsterByID(this.monsters, this.monsterId, true);
		this.points = this.GetPoints(this.monsters.Count);
		int num = 0;
		while (num < this.points.Count && num < this.monsters.Count)
		{
			BeActor beActor = this.monsters[num];
			if (beActor == null || beActor.IsDead())
			{
				this.startPoints.Add(VInt3.zero);
				this.moveDistance.Add(0);
				this.readyFlags.Add(false);
			}
			else
			{
				this.startPoints.Add(beActor.GetPosition());
				VInt3 vint = beActor.GetPosition() - this.points[num];
				this.moveDistance.Add(vint.magnitude);
				beActor.aiManager.StopCurrentCommand();
				beActor.aiManager.Stop();
				if (beActor.IsCastingSkill())
				{
					beActor.CancelSkill(beActor.GetCurSkillID(), true);
					beActor.Locomote(new BeStateData(0, 0), true);
				}
				this.readyFlags.Add(true);
			}
			num++;
		}
		base.owner.delayCaller.DelayCall(30, delegate
		{
			int num2 = 0;
			while (num2 < this.points.Count && num2 < this.monsters.Count)
			{
				BeActor beActor2 = this.monsters[num2];
				if (beActor2 != null && !beActor2.IsDead() && !beActor2.IsInPassiveState())
				{
					beActor2.ChangeRunMode(true);
					beActor2.ClearMoveSpeed(7);
					VInt3 vint2 = (this.points[num2] - beActor2.GetPosition()).NormalizeTo(this.speed);
					beActor2.SetMoveSpeedX(vint2.x);
					beActor2.SetMoveSpeedY(vint2.y);
					beActor2.SetFace(vint2.x < 0, false, false);
					beActor2.m_pkGeActor.ChangeAction("Anim_Walk", 0.6f, true, true, false);
					beActor2.buffController.TryAddBuff(1, GlobalLogic.VALUE_20000, 1);
				}
				num2++;
			}
		}, 0, 0, false);
	}

	// Token: 0x060188E5 RID: 100581 RVA: 0x007AB2F0 File Offset: 0x007A96F0
	private void SetMonsterIdle(int index)
	{
		this.monsters[index].m_pkGeActor.ChangeAction("Anim_Idle", 0.25f, false, true, false);
		this.monsters[index].SetFace(base.owner.GetFace(), false, false);
		this.monsters[index].SetPosition(this.points[index], false, true, false);
		this.monsters[index].ResetMoveCmd();
		this.readyFlags[index] = false;
	}

	// Token: 0x060188E6 RID: 100582 RVA: 0x007AB380 File Offset: 0x007A9780
	public override void OnUpdate(int iDeltime)
	{
		if (this.curPhase == 2)
		{
			int num = 0;
			while (num < this.points.Count && num < this.monsters.Count)
			{
				if (this.readyFlags[num])
				{
					if (this.monsters[num] != null)
					{
						if (this.monsters[num].IsDead())
						{
							this.readyFlags[num] = false;
						}
						else if (this.monsters[num].IsInPassiveState())
						{
							this.monsters[num].buffController.RemoveBuff(1, 0, 0);
							this.readyFlags[num] = false;
						}
						else if ((this.monsters[num].GetPosition() - this.points[num]).magnitude < GlobalLogic.VALUE_3000)
						{
							this.SetMonsterIdle(num);
						}
						else if ((this.monsters[num].GetPosition() - this.startPoints[num]).magnitude >= this.moveDistance[num])
						{
							this.SetMonsterIdle(num);
						}
					}
				}
				num++;
			}
			if (this._checkReady())
			{
				((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
			}
		}
		else if (this.curPhase == 3)
		{
			if (this.count < this.skillCount)
			{
				this.timer += iDeltime;
				if (this.timer >= this.skillCd)
				{
					this.timer = 0;
					this.count++;
					this.MonstersUseSkill();
				}
			}
			else
			{
				this.timer += iDeltime;
				if (this.timer >= GlobalLogic.VALUE_1000)
				{
					((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
				}
			}
		}
	}

	// Token: 0x060188E7 RID: 100583 RVA: 0x007AB594 File Offset: 0x007A9994
	private bool _checkReady()
	{
		for (int i = 0; i < this.readyFlags.Count; i++)
		{
			if (this.readyFlags[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060188E8 RID: 100584 RVA: 0x007AB5D1 File Offset: 0x007A99D1
	public override void OnCancel()
	{
		this._resetMonsters();
	}

	// Token: 0x060188E9 RID: 100585 RVA: 0x007AB5D9 File Offset: 0x007A99D9
	public override void OnFinish()
	{
		this._resetMonsters();
	}

	// Token: 0x060188EA RID: 100586 RVA: 0x007AB5E4 File Offset: 0x007A99E4
	private void _resetMonsters()
	{
		base.owner.buffController.RemoveBuff(1, 0, 0);
		int num = 0;
		while (num < this.points.Count && num < this.monsters.Count)
		{
			BeActor beActor = this.monsters[num];
			if (beActor != null && !beActor.IsDead())
			{
				beActor.buffController.RemoveBuff(1, 0, 0);
				beActor.aiManager.Start();
				beActor.ChangeRunMode(false);
			}
			num++;
		}
		this.points.Clear();
		this.monsters.Clear();
		this.readyFlags.Clear();
	}

	// Token: 0x04011B74 RID: 72564
	private int monsterId;

	// Token: 0x04011B75 RID: 72565
	private int skillId;

	// Token: 0x04011B76 RID: 72566
	private int skillCount;

	// Token: 0x04011B77 RID: 72567
	private int skillCd;

	// Token: 0x04011B78 RID: 72568
	private int unitDis = 20000;

	// Token: 0x04011B79 RID: 72569
	private int speed = 40000;

	// Token: 0x04011B7A RID: 72570
	private int useSkillNumber;

	// Token: 0x04011B7B RID: 72571
	private List<VInt3> points = new List<VInt3>();

	// Token: 0x04011B7C RID: 72572
	private List<BeActor> monsters = new List<BeActor>();

	// Token: 0x04011B7D RID: 72573
	private List<VInt3> startPoints = new List<VInt3>();

	// Token: 0x04011B7E RID: 72574
	private List<int> moveDistance = new List<int>();

	// Token: 0x04011B7F RID: 72575
	private List<bool> readyFlags = new List<bool>();

	// Token: 0x04011B80 RID: 72576
	private int timer;

	// Token: 0x04011B81 RID: 72577
	private int count;
}
