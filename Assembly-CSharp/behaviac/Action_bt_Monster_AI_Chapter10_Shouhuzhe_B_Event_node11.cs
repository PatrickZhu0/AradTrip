using System;

namespace behaviac
{
	// Token: 0x0200313C RID: 12604
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node11 : Action
	{
		// Token: 0x06014B1B RID: 84763 RVA: 0x0063B57B File Offset: 0x0063997B
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522052;
		}

		// Token: 0x06014B1C RID: 84764 RVA: 0x0063B59C File Offset: 0x0063999C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E494 RID: 58516
		private BE_Target method_p0;

		// Token: 0x0400E495 RID: 58517
		private int method_p1;
	}
}
