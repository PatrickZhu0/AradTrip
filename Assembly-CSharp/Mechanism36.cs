using System;
using System.Collections.Generic;

// Token: 0x020043E2 RID: 17378
public class Mechanism36 : BeMechanism
{
	// Token: 0x060181D1 RID: 98769 RVA: 0x0077EEEC File Offset: 0x0077D2EC
	public Mechanism36(int mid, int lv) : base(mid, lv)
	{
		this.m_ActorId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_AreaNum = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_SummonWaveNum = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_SummonAreaNum = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.m_SummonNum = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.m_SummonTimeDelay = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		this.m_EntitySpeed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x060181D2 RID: 98770 RVA: 0x0077F050 File Offset: 0x0077D450
	public override void OnStart()
	{
		this.SummonMonster();
	}

	// Token: 0x060181D3 RID: 98771 RVA: 0x0077F058 File Offset: 0x0077D458
	public override void OnUpdate(int deltaTime)
	{
		if (this.m_SummonMonsterList.Count > 0)
		{
			for (int i = 0; i < this.m_SummonMonsterList.Count; i++)
			{
				if (this.m_SummonMonsterList[i] != null)
				{
					this.Move(this.m_SummonMonsterList[i]);
				}
			}
		}
	}

	// Token: 0x060181D4 RID: 98772 RVA: 0x0077F0B8 File Offset: 0x0077D4B8
	protected void Move(BeActor actor)
	{
		if (actor.IsDead())
		{
			return;
		}
		actor.ResetMoveCmd();
		actor.speedConfig = new VInt3(this.m_EntitySpeed.i, this.m_EntitySpeed.i, 0);
		if (!actor.GetFace())
		{
			actor.ModifyMoveCmd(0, true);
		}
		else
		{
			actor.ModifyMoveCmd(1, true);
		}
	}

	// Token: 0x060181D5 RID: 98773 RVA: 0x0077F11C File Offset: 0x0077D51C
	protected void SummonMonster()
	{
		bool ownerFace = base.owner.GetFace();
		for (int i = 0; i < this.m_SummonWaveNum; i++)
		{
			int num = i;
			base.owner.delayCaller.DelayCall(this.m_SummonTimeDelay + this.m_SummonTimeDelay * num, delegate
			{
				if (this.isRunning)
				{
					this.SummonOneWave(ownerFace);
				}
			}, 0, 0, false);
		}
	}

	// Token: 0x060181D6 RID: 98774 RVA: 0x0077F190 File Offset: 0x0077D590
	protected void SummonOneWave(bool ownerFace)
	{
		List<VInt3> summonPos = this.GetSummonPos(ownerFace);
		for (int i = 0; i < summonPos.Count; i++)
		{
			this.SummonOneArea(summonPos[i], ownerFace);
		}
	}

	// Token: 0x060181D7 RID: 98775 RVA: 0x0077F1CC File Offset: 0x0077D5CC
	protected void SummonOneArea(VInt3 bornPos, bool face)
	{
		VInt3 position = base.owner.GetPosition();
		for (int i = 0; i < this.m_SummonNum; i++)
		{
			base.owner.delayCaller.DelayCall(this.m_TimeAcc * i, delegate
			{
				if (this.isRunning)
				{
					BeActor beActor = this.owner.CurrentBeScene.CreateMonster(this.m_ActorId + this.level * 100, false, null, this.level, this.owner.GetCamp(), null, false);
					beActor.aiManager.Stop();
					beActor.SetPosition(bornPos, true, true, false);
					beActor.SetRestrainPosition(false);
					beActor.stateController.SetAbilityEnable(BeAbilityType.BLOCK, false);
					beActor.SetFace(face, false, false);
					this.m_SummonMonsterList.Add(beActor);
				}
			}, 0, 0, false);
		}
	}

	// Token: 0x060181D8 RID: 98776 RVA: 0x0077F240 File Offset: 0x0077D640
	protected List<VInt3> GetSummonPos(bool face)
	{
		List<VInt3> areaBorn = this.GetAreaBorn(face);
		int count = areaBorn.Count;
		List<VInt3> list = new List<VInt3>();
		for (int i = 0; i < this.m_SummonAreaNum; i++)
		{
			int index = base.FrameRandom.InRange(0, areaBorn.Count);
			list.Add(areaBorn[index]);
			areaBorn.Remove(areaBorn[index]);
		}
		return list;
	}

	// Token: 0x060181D9 RID: 98777 RVA: 0x0077F2AC File Offset: 0x0077D6AC
	protected List<VInt3> GetAreaBorn(bool face)
	{
		List<VInt3> list = new List<VInt3>();
		list.Clear();
		BeScene currentBeScene = base.owner.CurrentBeScene;
		int num = currentBeScene.logicZSize.y - currentBeScene.logicZSize.x;
		int num2 = num / this.m_AreaNum;
		VInt3 zero = VInt3.zero;
		int x = (!face) ? currentBeScene.logicXSize.x : currentBeScene.logicXSize.y;
		for (int i = 0; i < this.m_AreaNum; i++)
		{
			if (i == 0)
			{
				zero = new VInt3(x, currentBeScene.logicZSize.x + num2 / 2, base.owner.GetPosition().z);
			}
			else
			{
				zero = new VInt3(x, currentBeScene.logicZSize.x + num2 * i + num2 / 2, base.owner.GetPosition().z);
			}
			list.Add(zero);
		}
		return list;
	}

	// Token: 0x060181DA RID: 98778 RVA: 0x0077F3A9 File Offset: 0x0077D7A9
	public override void OnFinish()
	{
	}

	// Token: 0x0401162F RID: 71215
	protected int m_ActorId;

	// Token: 0x04011630 RID: 71216
	protected int m_AreaNum;

	// Token: 0x04011631 RID: 71217
	protected int m_SummonWaveNum;

	// Token: 0x04011632 RID: 71218
	protected int m_SummonAreaNum;

	// Token: 0x04011633 RID: 71219
	protected int m_SummonNum;

	// Token: 0x04011634 RID: 71220
	protected int m_SummonTimeDelay;

	// Token: 0x04011635 RID: 71221
	protected VInt m_EntitySpeed = 0;

	// Token: 0x04011636 RID: 71222
	protected List<BeActor> m_SummonMonsterList = new List<BeActor>();

	// Token: 0x04011637 RID: 71223
	protected int m_TimeAcc = 500;

	// Token: 0x04011638 RID: 71224
	protected List<VInt3> m_AreaBornPos = new List<VInt3>();
}
