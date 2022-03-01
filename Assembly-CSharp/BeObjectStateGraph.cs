using System;

// Token: 0x0200419B RID: 16795
public sealed class BeObjectStateGraph : BeStatesGraph
{
	// Token: 0x060170AC RID: 94380 RVA: 0x0071139C File Offset: 0x0070F79C
	public override void InitStatesGraph()
	{
		BeStates rkStates = new BeStates(0, 0, delegate(BeStates pkState)
		{
			int currentStage = this.logicObject.currentStage;
			if (currentStage > 0)
			{
				this.logicObject.PlayAction(string.Format("Idle{0}", currentStage), 1f);
			}
			else if (currentStage == 0)
			{
				this.logicObject.PlayAction(ActionType.ActionType_IDLE, 1f, false);
			}
			base.SetCurrentStatesTimeout(-1, false);
		}, null, null, null);
		this.AddStates2Graph(rkStates);
		BeStates rkStates2 = new BeStates(16, 2, delegate(BeStates pkState)
		{
			if (this.logicObject.HasAction(ActionType.ActionType_DEAD))
			{
				this.logicObject.PlayAction(ActionType.ActionType_DEAD, 1f, false);
				this.logicObject.PlayDeadEffect();
				base.SetCurrentStatesTimeout(this.logicObject.m_cpkCurEntityActionInfo.fRealFramesTime, false);
			}
			else
			{
				base.SetCurrentStatesTimeout(GlobalLogic.VALUE_10, false);
			}
		}, delegate(BeStates pkState)
		{
			this.logicObject.m_iEntityLifeState = 4;
		}, null, null);
		this.AddStates2Graph(rkStates2);
	}

	// Token: 0x04010980 RID: 67968
	public BeObject logicObject;
}
