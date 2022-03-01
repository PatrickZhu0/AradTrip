using System;

namespace behaviac
{
	// Token: 0x02003ACA RID: 15050
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node18 : Action
	{
		// Token: 0x06015D53 RID: 89427 RVA: 0x0069890E File Offset: 0x00696D0E
		public Action_bt_Monster_AI_Tuanben_Kuangsha_Action_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570141;
		}

		// Token: 0x06015D54 RID: 89428 RVA: 0x0069892F File Offset: 0x00696D2F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F662 RID: 63074
		private BE_Target method_p0;

		// Token: 0x0400F663 RID: 63075
		private int method_p1;
	}
}
