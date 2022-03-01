using System;

// Token: 0x020041A1 RID: 16801
public sealed class BeProjectileStateGraph : BeStatesGraph
{
	// Token: 0x060170CB RID: 94411 RVA: 0x007119B0 File Offset: 0x0070FDB0
	public override void InitStatesGraph()
	{
		BeStates beStates = new BeStates(18, 0, delegate(BeStates state)
		{
			if (this.pkProjectile.HasAction(BeEntity.ActionConfigNames[23]))
			{
				this.pkProjectile.PlayAction(ActionType.ActionType_BIRTH, 1f, false);
				base.SetCurrentStatesTimeout(this.pkProjectile.GetCurrentActionDuration(), false);
			}
			else
			{
				base.SetCurrentStatesTimeout(GlobalLogic.VALUE_10, false);
			}
		}, delegate(BeStates pkState)
		{
			this.SwitchStates(new BeStateData(0, 0));
		}, null, null);
		BeStates beStates2 = new BeStates(0, 0, delegate(BeStates pkState)
		{
			this.pkProjectile.PlayAction(ActionType.ActionType_IDLE, 1f, false);
			if (this.pkProjectile.m_eType == ProjectType.BULLET || this.pkProjectile.m_eType == ProjectType.SINGLE)
			{
				int lifeTime = this.pkProjectile.GetLifeTime();
				bool force = lifeTime > 0;
				base.SetCurrentStatesTimeout(lifeTime, force);
			}
		}, delegate(BeStates pkState)
		{
			this.pkProjectile.DoDie();
		}, null, null);
		BeStatesGraph.SGAddEventHandler2States(beStates2, new BeEventsHandler(4, delegate(BeStates pkState)
		{
			if (this.pkProjectile.m_eType == ProjectType.BULLET || this.pkProjectile.m_eType == ProjectType.SINGLE)
			{
				if (this.pkProjectile.delayDead > 0)
				{
					if (this.pkProjectile.markDead)
					{
						this.pkProjectile.ClearMoveSpeed(7);
						this.pkProjectile.m_pkGeActor.Pause(63, true);
						return;
					}
					if (this.pkProjectile.hitGroundClick)
					{
						this.pkProjectile.ClearMoveSpeed(6);
						this.pkProjectile.SetMoveSpeedZ(3);
					}
					else
					{
						this.pkProjectile.ClearMoveSpeed(7);
					}
					this.pkProjectile.markDead = true;
					this.pkProjectile.projectileDeadType = ProjectileDeadType.HITGROUNDDEAD;
					this.pkProjectile.delayCaller.DelayCall(this.pkProjectile.delayDead, delegate
					{
						this.pkProjectile.DoDie();
					}, 0, 0, false);
				}
				else
				{
					this.pkProjectile.projectileDeadType = ProjectileDeadType.HITGROUNDDEAD;
					this.pkProjectile.DoDie();
				}
			}
		}));
		this.AddStates2Graph(beStates2);
		BeStates rkStates = new BeStates(16, 2, delegate(BeStates pkState)
		{
			this.pkProjectile.ClearMoveSpeed(7);
			this.pkProjectile.OnDead();
			if (this.pkProjectile.playExtDead)
			{
				if (this.pkProjectile.HasAction("ExpDead"))
				{
					this.pkProjectile.PlayAction("ExpDead", 1f);
					base.SetCurrentStatesTimeout(this.pkProjectile.GetCurrentActionDuration(), false);
				}
				else
				{
					this.pkProjectile.m_iEntityLifeState = 4;
				}
			}
			else if (this.pkProjectile.projectileDeadType == ProjectileDeadType.HITGROUNDDEAD && this.pkProjectile.HasAction("HitGroundDead"))
			{
				this.pkProjectile.PlayAction("HitGroundDead", 1f);
				base.SetCurrentStatesTimeout(this.pkProjectile.GetCurrentActionDuration(), false);
			}
			else if (this.pkProjectile.HasAction(ActionType.ActionType_DEAD))
			{
				this.pkProjectile.PlayAction(ActionType.ActionType_DEAD, 1f, false);
				base.SetCurrentStatesTimeout(this.pkProjectile.GetCurrentActionDuration(), false);
			}
			else
			{
				this.pkProjectile.m_iEntityLifeState = 4;
			}
		}, delegate(BeStates pkState)
		{
			this.pkProjectile.m_iEntityLifeState = 4;
		}, null, null);
		this.AddStates2Graph(rkStates);
	}

	// Token: 0x040109A8 RID: 68008
	public BeProjectile pkProjectile;

	// Token: 0x040109A9 RID: 68009
	public int m_iPreState;
}
