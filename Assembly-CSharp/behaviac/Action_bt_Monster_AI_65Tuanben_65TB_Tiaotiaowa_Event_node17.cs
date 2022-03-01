using System;

namespace behaviac
{
	// Token: 0x02002D14 RID: 11540
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node17 : Action
	{
		// Token: 0x06014316 RID: 82710 RVA: 0x00610C8F File Offset: 0x0060F08F
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 506411;
			this.method_p2 = 200;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014317 RID: 82711 RVA: 0x00610CCA File Offset: 0x0060F0CA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCC6 RID: 56518
		private BE_Target method_p0;

		// Token: 0x0400DCC7 RID: 56519
		private int method_p1;

		// Token: 0x0400DCC8 RID: 56520
		private int method_p2;

		// Token: 0x0400DCC9 RID: 56521
		private int method_p3;

		// Token: 0x0400DCCA RID: 56522
		private int method_p4;
	}
}
