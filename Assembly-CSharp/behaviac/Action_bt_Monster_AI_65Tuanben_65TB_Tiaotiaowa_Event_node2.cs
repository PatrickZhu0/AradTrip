using System;

namespace behaviac
{
	// Token: 0x02002D0A RID: 11530
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node2 : Action
	{
		// Token: 0x06014302 RID: 82690 RVA: 0x0061091A File Offset: 0x0060ED1A
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 506406;
			this.method_p2 = 100;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014303 RID: 82691 RVA: 0x00610952 File Offset: 0x0060ED52
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCA6 RID: 56486
		private BE_Target method_p0;

		// Token: 0x0400DCA7 RID: 56487
		private int method_p1;

		// Token: 0x0400DCA8 RID: 56488
		private int method_p2;

		// Token: 0x0400DCA9 RID: 56489
		private int method_p3;

		// Token: 0x0400DCAA RID: 56490
		private int method_p4;
	}
}
