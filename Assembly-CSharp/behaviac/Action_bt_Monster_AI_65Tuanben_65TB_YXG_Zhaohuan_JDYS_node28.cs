using System;

namespace behaviac
{
	// Token: 0x02002D49 RID: 11593
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node28 : Action
	{
		// Token: 0x06014377 RID: 82807 RVA: 0x00612785 File Offset: 0x00610B85
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521973;
		}

		// Token: 0x06014378 RID: 82808 RVA: 0x006127A6 File Offset: 0x00610BA6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD3F RID: 56639
		private BE_Target method_p0;

		// Token: 0x0400DD40 RID: 56640
		private int method_p1;
	}
}
