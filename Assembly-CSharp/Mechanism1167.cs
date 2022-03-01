using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020042DC RID: 17116
public class Mechanism1167 : BeMechanism
{
	// Token: 0x06017AF1 RID: 97009 RVA: 0x0074C844 File Offset: 0x0074AC44
	public Mechanism1167(int mid, int lv) : base(mid, lv)
	{
		this.m_MonserLevel = lv;
	}

	// Token: 0x06017AF2 RID: 97010 RVA: 0x0074C880 File Offset: 0x0074AC80
	public override void OnInit()
	{
		this.m_MonsterId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			if (valueFromUnionCell > 0)
			{
				this.m_BuffIdList.Add(valueFromUnionCell);
			}
		}
		for (int j = 0; j < this.data.ValueC.Count; j++)
		{
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true);
			if (valueFromUnionCell2 > 0)
			{
				this.m_BuffInfoIdList.Add(valueFromUnionCell2);
			}
		}
		if (this.data.ValueD.Length > 0)
		{
			this.m_needChangePos = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) == 0);
		}
	}

	// Token: 0x06017AF3 RID: 97011 RVA: 0x0074C9AD File Offset: 0x0074ADAD
	public override void OnStart()
	{
		this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onHurtEntity, new BeEvent.BeEventHandleNew.Function(this.onHurtEntity));
	}

	// Token: 0x06017AF4 RID: 97012 RVA: 0x0074C9D4 File Offset: 0x0074ADD4
	public override void OnFinish()
	{
		base.OnFinish();
		for (int i = 0; i < this.m_summonLists.Count; i++)
		{
			Mechanism1167.SummonInfo summonInfo = this.m_summonLists[i];
			if (summonInfo.targetDeadHandle != null)
			{
				summonInfo.targetDeadHandle.Remove();
			}
			if (summonInfo.summonMonsterDeadHandle != null)
			{
				summonInfo.summonMonsterDeadHandle.Remove();
			}
			if (summonInfo.hitTarget != null)
			{
				this.RemoveFunction(summonInfo.hitTarget);
				summonInfo.hitTarget.SetPosition(summonInfo.originPos, false, true, false);
			}
		}
		this.m_summonLists.Clear();
	}

	// Token: 0x06017AF5 RID: 97013 RVA: 0x0074CA74 File Offset: 0x0074AE74
	private void onHurtEntity(BeEvent.BeEventParam param)
	{
		BeEntity beEntity = param.m_Obj as BeEntity;
		if (beEntity == null)
		{
			return;
		}
		BeEntity topOwner = beEntity.GetTopOwner(beEntity);
		if (topOwner == null || topOwner.GetPID() != base.owner.GetPID())
		{
			return;
		}
		BeActor beActor = param.m_Obj2 as BeActor;
		if (beActor == null || !beActor.isMainActor)
		{
			return;
		}
		BeActor beActor2 = base.owner.CurrentBeScene.SummonMonster(this.m_MonsterId, beActor.GetPosition(), base.owner.m_iCamp, null, false, this.m_MonserLevel, true, 0, false, false);
		if (beActor2 != null)
		{
			if (beActor2.IsDead() && base.owner.CurrentBeScene.state >= BeSceneState.onBulletTime)
			{
				return;
			}
			BeEventHandle summonMonsterDeadHandle = beActor2.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.OnSummonMonsterDead));
			this.AddBuffInfoToTarget(beActor);
			BeEventHandle targetDeadHandle = beActor.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.onTargetDead));
			VInt3 position = beActor2.GetPosition();
			this.m_summonLists.Add(new Mechanism1167.SummonInfo
			{
				summonMonster = beActor2,
				hitTarget = beActor,
				originPos = position,
				summonMonsterDeadHandle = summonMonsterDeadHandle,
				targetDeadHandle = targetDeadHandle
			});
			if (this.m_needChangePos)
			{
				beActor.SetPosition(new VInt3(position.x, position.y, -10 * VInt.one.i), false, true, false);
			}
		}
	}

	// Token: 0x06017AF6 RID: 97014 RVA: 0x0074CBE8 File Offset: 0x0074AFE8
	private void OnSummonMonsterDead(object[] args)
	{
		if (args.Length < 3)
		{
			return;
		}
		BeActor beActor = args[2] as BeActor;
		if (beActor == null)
		{
			return;
		}
		for (int i = 0; i < this.m_summonLists.Count; i++)
		{
			Mechanism1167.SummonInfo summonInfo = this.m_summonLists[i];
			if (summonInfo.summonMonster != null && summonInfo.summonMonster.GetPID() == beActor.GetPID())
			{
				if (summonInfo.summonMonsterDeadHandle != null)
				{
					summonInfo.summonMonsterDeadHandle.Remove();
				}
				if (summonInfo.targetDeadHandle != null)
				{
					summonInfo.targetDeadHandle.Remove();
				}
				if (summonInfo.hitTarget != null)
				{
					this.RemoveFunction(summonInfo.hitTarget);
					summonInfo.hitTarget.SetPosition(summonInfo.originPos, false, true, false);
				}
				this.m_summonLists.RemoveAt(i);
				return;
			}
		}
	}

	// Token: 0x06017AF7 RID: 97015 RVA: 0x0074CCC0 File Offset: 0x0074B0C0
	private void onTargetDead(object[] args)
	{
		if (args.Length < 3)
		{
			return;
		}
		BeActor beActor = args[2] as BeActor;
		if (beActor == null)
		{
			return;
		}
		for (int i = 0; i < this.m_summonLists.Count; i++)
		{
			Mechanism1167.SummonInfo summonInfo = this.m_summonLists[i];
			if (summonInfo.hitTarget != null && summonInfo.hitTarget.GetPID() == beActor.GetPID())
			{
				if (summonInfo.summonMonster != null && !summonInfo.summonMonster.IsDead())
				{
					summonInfo.summonMonster.DoDead(false);
				}
				return;
			}
		}
	}

	// Token: 0x06017AF8 RID: 97016 RVA: 0x0074CD5C File Offset: 0x0074B15C
	protected void AddBuffInfoToTarget(BeActor target)
	{
		for (int i = 0; i < this.m_BuffInfoIdList.Count; i++)
		{
			target.buffController.TryAddBuff(this.m_BuffInfoIdList[i], null, false, null, 0);
		}
	}

	// Token: 0x06017AF9 RID: 97017 RVA: 0x0074CDA4 File Offset: 0x0074B1A4
	protected void RemoveFunction(BeActor target)
	{
		for (int i = 0; i < this.m_BuffIdList.Count; i++)
		{
			target.buffController.RemoveBuff(this.m_BuffIdList[i], 0, 0);
		}
	}

	// Token: 0x04011052 RID: 69714
	protected List<int> m_BuffInfoIdList = new List<int>();

	// Token: 0x04011053 RID: 69715
	protected List<int> m_BuffIdList = new List<int>();

	// Token: 0x04011054 RID: 69716
	protected int m_MonsterId;

	// Token: 0x04011055 RID: 69717
	protected int m_MonserLevel;

	// Token: 0x04011056 RID: 69718
	private bool m_needChangePos = true;

	// Token: 0x04011057 RID: 69719
	private List<Mechanism1167.SummonInfo> m_summonLists = new List<Mechanism1167.SummonInfo>();

	// Token: 0x020042DD RID: 17117
	private class SummonInfo
	{
		// Token: 0x04011058 RID: 69720
		public BeActor summonMonster;

		// Token: 0x04011059 RID: 69721
		public BeActor hitTarget;

		// Token: 0x0401105A RID: 69722
		public VInt3 originPos;

		// Token: 0x0401105B RID: 69723
		public BeEventHandle summonMonsterDeadHandle;

		// Token: 0x0401105C RID: 69724
		public BeEventHandle targetDeadHandle;
	}
}
