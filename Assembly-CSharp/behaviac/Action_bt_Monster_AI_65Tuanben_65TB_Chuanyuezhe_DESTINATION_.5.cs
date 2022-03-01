using System;

namespace behaviac
{
	// Token: 0x02002B7C RID: 11132
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node14 : Action
	{
		// Token: 0x06014005 RID: 81925 RVA: 0x00601654 File Offset: 0x005FFA54
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 42770021;
			this.method_p1 = true;
		}

		// Token: 0x06014006 RID: 81926 RVA: 0x00601675 File Offset: 0x005FFA75
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AssignAITarget(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA08 RID: 55816
		private int method_p0;

		// Token: 0x0400DA09 RID: 55817
		private bool method_p1;
	}
}
