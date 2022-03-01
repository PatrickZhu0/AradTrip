using System;
using System.Collections.Generic;

// Token: 0x0200429C RID: 17052
public class Mechanism1085 : BeMechanism
{
	// Token: 0x06017976 RID: 96630 RVA: 0x00744000 File Offset: 0x00742400
	public Mechanism1085(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017977 RID: 96631 RVA: 0x0074405C File Offset: 0x0074245C
	public override void OnInit()
	{
		this.chainEffect = this.data.StringValueA[0];
		this.chainMaxCount = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.effectID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017978 RID: 96632 RVA: 0x007440F8 File Offset: 0x007424F8
	public override void OnStart()
	{
		this.chainCount = 0;
		if (this.mEntitys == null)
		{
			this.mEntitys = new List<BeEntity>();
		}
		else
		{
			this.mEntitys.Clear();
		}
		if (base.owner != null)
		{
			this.doAttackTarget.Clear();
			this.effectTarget.Clear();
			base.owner.CurrentBeScene.GetEntitys2(this.mEntitys);
			this.effectTarget.Add(base.owner);
			BeActor beActor = this.FindNearestRangeTarget(base.owner.GetPosition(), this.chainMaxDistance, this.effectTarget);
			if (beActor != null)
			{
				this.startChain = true;
				this.fromActor = base.owner;
				this.toActor = beActor;
			}
		}
	}

	// Token: 0x06017979 RID: 96633 RVA: 0x007441B8 File Offset: 0x007425B8
	public override void OnUpdate(int deltaTime)
	{
		if (this.startChain)
		{
			this.chainTimer -= deltaTime;
			if (this.chainTimer > 0)
			{
				return;
			}
			if (this.fromActor != null && this.toActor != null)
			{
				this.Chain(this.fromActor, this.toActor);
				this.fromActor = this.toActor;
				this.toActor = this.FindNearestRangeTarget(this.fromActor.GetPosition(), this.chainMaxDistance, this.effectTarget);
				this.chainTimer = this.attackDuration;
			}
		}
	}

	// Token: 0x0601797A RID: 96634 RVA: 0x0074424E File Offset: 0x0074264E
	public override void OnFinish()
	{
		this.chainCount = 0;
		this.Clear();
	}

	// Token: 0x0601797B RID: 96635 RVA: 0x00744260 File Offset: 0x00742660
	private void Chain(BeActor fromActor, BeActor toActor)
	{
		this.chainCount++;
		if (this.chainCount > this.chainMaxCount)
		{
			return;
		}
		this.CreateChainEffect(fromActor, toActor);
		this.effectTarget.Add(toActor);
		if (base.owner.GetCamp() == toActor.GetCamp())
		{
			toActor.buffController.TryAddBuffInfo(this.buffInfoID, base.owner, 0);
		}
		else
		{
			Mechanism1085.ChainTarget chainTarget = new Mechanism1085.ChainTarget();
			chainTarget.target = toActor;
			chainTarget.isDead = false;
			chainTarget.handle = toActor.RegisterEvent(BeEventType.onDead, delegate(object[] args)
			{
				BeActor unitDead = args[2] as BeActor;
				this.SetUnitDead(unitDead);
				int[] array = (int[])args[0];
				if (!(bool)args[1])
				{
					array[0] = 1;
				}
			});
			this.doAttackTarget.Add(chainTarget);
			VInt3 position = toActor.GetPosition();
			position.z += VInt.one.i;
			base.owner._onHurtEntity(toActor, position, this.effectID);
		}
	}

	// Token: 0x0601797C RID: 96636 RVA: 0x00744344 File Offset: 0x00742744
	private void CreateChainEffect(BeActor fromActor, BeActor toActor)
	{
		if (fromActor == null || toActor == null || fromActor.m_pkGeActor == null)
		{
			return;
		}
		fromActor.m_pkGeActor.CreateChainEffect(toActor, this.chainEffect, EffectTimeType.SYNC_ANIMATION, false);
	}

	// Token: 0x0601797D RID: 96637 RVA: 0x00744372 File Offset: 0x00742772
	private void ClearChainEffect(BeActor actor)
	{
		if (actor == null || actor.m_pkGeActor == null)
		{
			return;
		}
		actor.m_pkGeActor.ClearChainEffect();
	}

	// Token: 0x0601797E RID: 96638 RVA: 0x00744394 File Offset: 0x00742794
	private void SetUnitDead(BeActor actor)
	{
		if (this.doAttackTarget != null)
		{
			for (int i = 0; i < this.doAttackTarget.Count; i++)
			{
				if (this.doAttackTarget[i].target.GetPID() == actor.GetPID())
				{
					this.doAttackTarget[i].isDead = true;
				}
			}
		}
	}

	// Token: 0x0601797F RID: 96639 RVA: 0x007443FC File Offset: 0x007427FC
	protected void Clear()
	{
		for (int i = 0; i < this.effectTarget.Count; i++)
		{
			this.ClearChainEffect(this.effectTarget[i]);
		}
		this.effectTarget.Clear();
		for (int j = 0; j < this.doAttackTarget.Count; j++)
		{
			if (this.doAttackTarget[j].handle != null)
			{
				this.doAttackTarget[j].handle.Remove();
			}
			if (this.doAttackTarget[j].target != null)
			{
				if (this.doAttackTarget[j].target.GetLifeState() == 2)
				{
					if (this.doAttackTarget[j].target.sgGetCurrentState() != 13 || this.doAttackTarget[j].target.GetPosition().z <= 0)
					{
						if (this.doAttackTarget[j].isDead || this.doAttackTarget[j].target.IsDead() || (this.doAttackTarget[j].target.GetEntityData() != null && this.doAttackTarget[j].target.GetEntityData().GetHP() <= 0))
						{
							this.doAttackTarget[j].target.DoDead(false);
						}
					}
				}
			}
		}
		this.doAttackTarget.Clear();
	}

	// Token: 0x06017980 RID: 96640 RVA: 0x00744598 File Offset: 0x00742998
	private BeActor FindNearestRangeTarget(VInt3 pos, VInt radius, List<BeActor> inList = null)
	{
		BeActor result = null;
		int num = int.MaxValue;
		int num2 = int.MaxValue;
		VInt2 a = new VInt2(pos.x, pos.y);
		for (int i = 0; i < this.mEntitys.Count; i++)
		{
			if (this.mEntitys[i] is BeActor && !this.mEntitys[i].IsDead())
			{
				if (!(this.mEntitys[i] as BeActor).IsSkillMonster())
				{
					if (!(this.mEntitys[i] as BeActor).IsSummonMonster())
					{
						if (this.mEntitys[i].stateController.CanBeTargeted() || (this.mEntitys[i] as BeActor).GetCamp() == base.owner.GetCamp())
						{
							if (inList == null || !inList.Contains(this.mEntitys[i] as BeActor))
							{
								VInt3 position = this.mEntitys[i].GetPosition();
								VInt2 b = new VInt2(position.x, position.y);
								int magnitude = (a - b).magnitude;
								if (magnitude <= radius && Math.Abs(a.y - b.y) <= num && (Math.Abs(a.y - b.y) != num || (Math.Abs(a.y - b.y) == num && Math.Abs(a.x - b.x) < num2)))
								{
									num = Math.Abs(a.y - b.y);
									num2 = Math.Abs(a.x - b.x);
									result = (this.mEntitys[i] as BeActor);
								}
							}
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x04010F38 RID: 69432
	private string chainEffect;

	// Token: 0x04010F39 RID: 69433
	private int chainMaxCount;

	// Token: 0x04010F3A RID: 69434
	private int buffInfoID;

	// Token: 0x04010F3B RID: 69435
	private int effectID;

	// Token: 0x04010F3C RID: 69436
	private VInt chainMaxDistance = VInt.one.i * 5;

	// Token: 0x04010F3D RID: 69437
	private int attackDuration = GlobalLogic.VALUE_300;

	// Token: 0x04010F3E RID: 69438
	private List<Mechanism1085.ChainTarget> doAttackTarget = new List<Mechanism1085.ChainTarget>();

	// Token: 0x04010F3F RID: 69439
	private List<BeActor> effectTarget = new List<BeActor>();

	// Token: 0x04010F40 RID: 69440
	private int chainCount;

	// Token: 0x04010F41 RID: 69441
	private List<BeEntity> mEntitys = new List<BeEntity>();

	// Token: 0x04010F42 RID: 69442
	private bool startChain;

	// Token: 0x04010F43 RID: 69443
	private BeActor fromActor;

	// Token: 0x04010F44 RID: 69444
	private BeActor toActor;

	// Token: 0x04010F45 RID: 69445
	private int chainTimer;

	// Token: 0x0200429D RID: 17053
	private class ChainTarget
	{
		// Token: 0x04010F46 RID: 69446
		public BeActor target;

		// Token: 0x04010F47 RID: 69447
		public BeEventHandle handle;

		// Token: 0x04010F48 RID: 69448
		public bool isDead;
	}
}
