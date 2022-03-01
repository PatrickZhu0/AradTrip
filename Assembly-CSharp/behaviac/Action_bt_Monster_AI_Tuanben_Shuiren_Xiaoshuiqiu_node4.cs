using System;

namespace behaviac
{
	// Token: 0x02003B77 RID: 15223
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node4 : Action
	{
		// Token: 0x06015EA2 RID: 89762 RVA: 0x0069F554 File Offset: 0x0069D954
		public Action_bt_Monster_AI_Tuanben_Shuiren_Xiaoshuiqiu_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x06015EA3 RID: 89763 RVA: 0x0069F56B File Offset: 0x0069D96B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F768 RID: 63336
		private DestinationType method_p0;
	}
}
