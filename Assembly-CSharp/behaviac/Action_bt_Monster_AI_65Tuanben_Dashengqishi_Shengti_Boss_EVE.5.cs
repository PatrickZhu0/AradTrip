using System;

namespace behaviac
{
	// Token: 0x02002E8E RID: 11918
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node6 : Action
	{
		// Token: 0x060145F7 RID: 83447 RVA: 0x00620A27 File Offset: 0x0061EE27
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 2;
		}

		// Token: 0x060145F8 RID: 83448 RVA: 0x00620A44 File Offset: 0x0061EE44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF7A RID: 57210
		private int method_p0;

		// Token: 0x0400DF7B RID: 57211
		private int method_p1;
	}
}
