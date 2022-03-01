using System;

namespace behaviac
{
	// Token: 0x02002276 RID: 8822
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node26 : Action
	{
		// Token: 0x06012E70 RID: 77424 RVA: 0x0059302D File Offset: 0x0059142D
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Enemy;
			this.method_p1 = BE_Equal.NotEqual;
			this.method_p2 = BE_State.DAODI;
		}

		// Token: 0x06012E71 RID: 77425 RVA: 0x00593051 File Offset: 0x00591451
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CheckState(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C87C RID: 51324
		private BE_Target method_p0;

		// Token: 0x0400C87D RID: 51325
		private BE_Equal method_p1;

		// Token: 0x0400C87E RID: 51326
		private BE_State method_p2;
	}
}
