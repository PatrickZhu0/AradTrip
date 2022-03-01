using System;
using System.Collections.Generic;

// Token: 0x0200438C RID: 17292
public class Mechanism2084 : BeMechanism
{
	// Token: 0x06017FA1 RID: 98209 RVA: 0x0076DA03 File Offset: 0x0076BE03
	public Mechanism2084(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017FA2 RID: 98210 RVA: 0x0076DA18 File Offset: 0x0076BE18
	public override void OnInit()
	{
		this.m_SummonDataList.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			Mechanism2084.SummonEntityData item = default(Mechanism2084.SummonEntityData);
			item.EntityId = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			item.HurtId = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			item.DelayAttackTime = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
			item.RepeatAttackTime = TableManager.GetValueFromUnionCell(this.data.ValueE[i], this.level, true);
			item.RepeatAttackCount = TableManager.GetValueFromUnionCell(this.data.ValueF[i], this.level, true);
			this.m_SummonDataList.Add(item);
		}
		this.m_SummonRate = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017FA3 RID: 98211 RVA: 0x0076DB5A File Offset: 0x0076BF5A
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, new BeEventHandle.Del(this.HitOther));
	}

	// Token: 0x06017FA4 RID: 98212 RVA: 0x0076DB84 File Offset: 0x0076BF84
	private void HitOther(object[] args)
	{
		if (args.Length > 6)
		{
			BeProjectile beProjectile = args[6] as BeProjectile;
			if (beProjectile != null && this.CheckSummonProjectileId(beProjectile.m_iResID))
			{
				return;
			}
		}
		int hurtId = (int)args[1];
		if (this.CheckSummonHurtId(hurtId))
		{
			return;
		}
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		this.TryCreateEntity(beActor.GetPosition(), beActor);
	}

	// Token: 0x06017FA5 RID: 98213 RVA: 0x0076DBF0 File Offset: 0x0076BFF0
	private void TryCreateEntity(VInt3 pos, BeActor target)
	{
		int num = (int)base.FrameRandom.Random((uint)GlobalLogic.VALUE_1000);
		if (this.m_SummonRate < num)
		{
			return;
		}
		ushort index = base.FrameRandom.Random((uint)this.m_SummonDataList.Count);
		Mechanism2084.SummonEntityData entityData = this.m_SummonDataList[(int)index];
		base.owner.AddEntity(entityData.EntityId, pos, 1, 0);
		if (entityData.DelayAttackTime > 0)
		{
			base.owner.delayCaller.DelayCall(entityData.DelayAttackTime, delegate
			{
				if (this.owner != null && !this.owner.IsDead() && target != null && !target.IsDead())
				{
					this.owner.DoAttackTo(target, entityData.HurtId, true, false);
				}
			}, 0, 0, false);
			if (entityData.RepeatAttackCount > 0)
			{
				for (int i = 0; i < entityData.RepeatAttackCount; i++)
				{
					int ms = entityData.DelayAttackTime + entityData.RepeatAttackTime * (i + 1);
					base.owner.delayCaller.DelayCall(ms, delegate
					{
						if (this.owner != null && !this.owner.IsDead() && target != null && !target.IsDead())
						{
							this.owner.DoAttackTo(target, entityData.HurtId, true, false);
						}
					}, 0, 0, false);
				}
			}
		}
		else
		{
			base.owner.DoAttackTo(target, entityData.HurtId, true, false);
		}
	}

	// Token: 0x06017FA6 RID: 98214 RVA: 0x0076DD40 File Offset: 0x0076C140
	private bool CheckSummonProjectileId(int resId)
	{
		for (int i = 0; i < this.m_SummonDataList.Count; i++)
		{
			if (this.m_SummonDataList[i].EntityId == resId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06017FA7 RID: 98215 RVA: 0x0076DD88 File Offset: 0x0076C188
	private bool CheckSummonHurtId(int hurtId)
	{
		for (int i = 0; i < this.m_SummonDataList.Count; i++)
		{
			if (this.m_SummonDataList[i].HurtId == hurtId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04011433 RID: 70707
	private int m_SummonRate;

	// Token: 0x04011434 RID: 70708
	private List<Mechanism2084.SummonEntityData> m_SummonDataList = new List<Mechanism2084.SummonEntityData>();

	// Token: 0x0200438D RID: 17293
	private struct SummonEntityData
	{
		// Token: 0x04011435 RID: 70709
		public int EntityId;

		// Token: 0x04011436 RID: 70710
		public int HurtId;

		// Token: 0x04011437 RID: 70711
		public int DelayAttackTime;

		// Token: 0x04011438 RID: 70712
		public int RepeatAttackTime;

		// Token: 0x04011439 RID: 70713
		public int RepeatAttackCount;
	}
}
