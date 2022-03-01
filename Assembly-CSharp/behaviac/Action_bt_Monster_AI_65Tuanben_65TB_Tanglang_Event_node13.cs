using System;

namespace behaviac
{
	// Token: 0x02002CAD RID: 11437
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node13 : Action
	{
		// Token: 0x0601424F RID: 82511 RVA: 0x0060CDAA File Offset: 0x0060B1AA
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521947;
		}

		// Token: 0x06014250 RID: 82512 RVA: 0x0060CDCB File Offset: 0x0060B1CB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC07 RID: 56327
		private BE_Target method_p0;

		// Token: 0x0400DC08 RID: 56328
		private int method_p1;
	}
}
