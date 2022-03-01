using System;

namespace behaviac
{
	// Token: 0x02002D4F RID: 11599
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node30 : Action
	{
		// Token: 0x06014383 RID: 82819 RVA: 0x006128EF File Offset: 0x00610CEF
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521973;
		}

		// Token: 0x06014384 RID: 82820 RVA: 0x00612910 File Offset: 0x00610D10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD4D RID: 56653
		private BE_Target method_p0;

		// Token: 0x0400DD4E RID: 56654
		private int method_p1;
	}
}
