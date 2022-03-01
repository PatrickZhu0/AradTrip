using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020043E5 RID: 17381
public class Mechanism39 : BeMechanism
{
	// Token: 0x060181EE RID: 98798 RVA: 0x0077FA0B File Offset: 0x0077DE0B
	public Mechanism39(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060181EF RID: 98799 RVA: 0x0077FA48 File Offset: 0x0077DE48
	public override void OnInit()
	{
		this.m_SummonTimeAcc = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Count > 0)
		{
			for (int i = 0; i < this.data.ValueB.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
				this.m_SummonNumList.Add(valueFromUnionCell);
			}
		}
		this.m_Radius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
		this.m_SummonEntityId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.m_AttachBuffIdPve = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.m_AttachBuffIdPvp = TableManager.GetValueFromUnionCell(this.data.ValueE[1], this.level, true);
		this.m_AttachMaxNum = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		this.m_SummonRadius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x060181F0 RID: 98800 RVA: 0x0077FBE8 File Offset: 0x0077DFE8
	public override void OnStart()
	{
		int num = GlobalLogic.VALUE_1000;
		for (int i = 0; i < base.owner.MechanismList.Count; i++)
		{
			Mechanism121 mechanism = base.owner.MechanismList[i] as Mechanism121;
			if (mechanism != null)
			{
				num += mechanism.radiusRate;
			}
		}
		this.m_Radius = this.m_Radius.i * VFactor.NewVFactor(num, GlobalLogic.VALUE_1000);
		this.SelectActorSummon();
	}

	// Token: 0x060181F1 RID: 98801 RVA: 0x0077FC6E File Offset: 0x0077E06E
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.m_CurrentTimeAcc >= this.m_SummonTimeAcc)
		{
			this.m_CurrentTimeAcc = 0;
			this.SelectActorSummon();
		}
		else
		{
			this.m_CurrentTimeAcc += deltaTime;
		}
	}

	// Token: 0x060181F2 RID: 98802 RVA: 0x0077FCA8 File Offset: 0x0077E0A8
	protected int GetEntityCount()
	{
		List<BeEntity> entities = base.owner.CurrentBeScene.GetEntities();
		int num = 0;
		if (entities.Count > 0)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].m_iResID == this.m_SummonEntityId && entities[i].GetOwner() == base.owner)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x060181F3 RID: 98803 RVA: 0x0077FD20 File Offset: 0x0077E120
	protected void SelectActorSummon()
	{
		if (this.GetEntityCount() >= this.m_SummonMax)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorInRange(list, base.owner.GetPosition(), this.m_Radius, -1, 0);
		for (int i = 0; i < list.Count; i++)
		{
			int buffID = (!BattleMain.IsModePvP(base.battleType)) ? this.m_AttachBuffIdPve : this.m_AttachBuffIdPvp;
			int buffCountByID = list[i].buffController.GetBuffCountByID(buffID);
			if (buffCountByID < this.m_AttachMaxNum && list[i].GetCamp() != base.owner.GetCamp())
			{
				this.SummonMonster(list[i]);
				break;
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x060181F4 RID: 98804 RVA: 0x0077FDF8 File Offset: 0x0077E1F8
	protected void SummonMonster(BeActor actor)
	{
		int num;
		if (this.m_SummonNumList.Count == 1)
		{
			num = this.m_SummonNumList[0];
		}
		else
		{
			num = base.FrameRandom.InRange(this.m_SummonNumList[0], this.m_SummonNumList[1] + 1);
		}
		for (int i = 0; i < num; i++)
		{
			VInt3 logicPosInRange = base.owner.CurrentBeScene.GetLogicPosInRange(actor, this.m_SummonRadius.i);
			base.owner.AddEntity(this.m_SummonEntityId, logicPosInRange, this.level, 0);
		}
	}

	// Token: 0x060181F5 RID: 98805 RVA: 0x0077FEA0 File Offset: 0x0077E2A0
	public override void OnFinish()
	{
		List<BeEntity> entities = base.owner.CurrentBeScene.GetEntities();
		if (entities.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < entities.Count; i++)
		{
			if (entities[i].m_iResID == this.m_SummonEntityId && entities[i] != null)
			{
				entities[i].OnRemove(false);
			}
		}
	}

	// Token: 0x04011648 RID: 71240
	protected int m_SummonTimeAcc;

	// Token: 0x04011649 RID: 71241
	protected List<int> m_SummonNumList = new List<int>();

	// Token: 0x0401164A RID: 71242
	protected VInt m_Radius = 3700;

	// Token: 0x0401164B RID: 71243
	protected int m_SummonEntityId;

	// Token: 0x0401164C RID: 71244
	protected int m_AttachBuffIdPve;

	// Token: 0x0401164D RID: 71245
	protected int m_AttachBuffIdPvp;

	// Token: 0x0401164E RID: 71246
	protected int m_AttachMaxNum;

	// Token: 0x0401164F RID: 71247
	protected VInt m_SummonRadius = 500;

	// Token: 0x04011650 RID: 71248
	protected int m_SummonMax = 10;

	// Token: 0x04011651 RID: 71249
	protected int m_CurrentTimeAcc;
}
