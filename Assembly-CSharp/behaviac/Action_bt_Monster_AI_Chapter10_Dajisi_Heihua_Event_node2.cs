using System;

namespace behaviac
{
	// Token: 0x020030D8 RID: 12504
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dajisi_Heihua_Event_node2 : Action
	{
		// Token: 0x06014A67 RID: 84583 RVA: 0x00637EB6 File Offset: 0x006362B6
		public Action_bt_Monster_AI_Chapter10_Dajisi_Heihua_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522998;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014A68 RID: 84584 RVA: 0x00637EF1 File Offset: 0x006362F1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3CD RID: 58317
		private BE_Target method_p0;

		// Token: 0x0400E3CE RID: 58318
		private int method_p1;

		// Token: 0x0400E3CF RID: 58319
		private int method_p2;

		// Token: 0x0400E3D0 RID: 58320
		private int method_p3;

		// Token: 0x0400E3D1 RID: 58321
		private int method_p4;
	}
}
