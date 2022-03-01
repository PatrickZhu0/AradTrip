using System;

namespace behaviac
{
	// Token: 0x020030DC RID: 12508
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dajisi_Heihua_Heianquyu_Event_node2 : Action
	{
		// Token: 0x06014A6E RID: 84590 RVA: 0x006380C2 File Offset: 0x006364C2
		public Action_bt_Monster_AI_Chapter10_Dajisi_Heihua_Heianquyu_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522992;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014A6F RID: 84591 RVA: 0x006380F9 File Offset: 0x006364F9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3D7 RID: 58327
		private BE_Target method_p0;

		// Token: 0x0400E3D8 RID: 58328
		private int method_p1;

		// Token: 0x0400E3D9 RID: 58329
		private int method_p2;

		// Token: 0x0400E3DA RID: 58330
		private int method_p3;

		// Token: 0x0400E3DB RID: 58331
		private int method_p4;
	}
}
