using System;

namespace behaviac
{
	// Token: 0x02002D12 RID: 11538
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node14 : Action
	{
		// Token: 0x06014312 RID: 82706 RVA: 0x00610BE6 File Offset: 0x0060EFE6
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 96;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014313 RID: 82707 RVA: 0x00610C1A File Offset: 0x0060F01A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCC0 RID: 56512
		private BE_Target method_p0;

		// Token: 0x0400DCC1 RID: 56513
		private int method_p1;

		// Token: 0x0400DCC2 RID: 56514
		private int method_p2;

		// Token: 0x0400DCC3 RID: 56515
		private int method_p3;

		// Token: 0x0400DCC4 RID: 56516
		private int method_p4;
	}
}
