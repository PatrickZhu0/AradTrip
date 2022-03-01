using System;

namespace behaviac
{
	// Token: 0x02002D9A RID: 11674
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node47 : Action
	{
		// Token: 0x06014415 RID: 82965 RVA: 0x00615C06 File Offset: 0x00614006
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node47()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 2;
		}

		// Token: 0x06014416 RID: 82966 RVA: 0x00615C23 File Offset: 0x00614023
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDDD RID: 56797
		private int method_p0;

		// Token: 0x0400DDDE RID: 56798
		private int method_p1;
	}
}
