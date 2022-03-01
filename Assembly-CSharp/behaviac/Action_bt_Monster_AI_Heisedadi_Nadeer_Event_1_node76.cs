using System;

namespace behaviac
{
	// Token: 0x0200352F RID: 13615
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node76 : Action
	{
		// Token: 0x060152A1 RID: 86689 RVA: 0x0065FCEE File Offset: 0x0065E0EE
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node76()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521790;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152A2 RID: 86690 RVA: 0x0065FD25 File Offset: 0x0065E125
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC29 RID: 60457
		private BE_Target method_p0;

		// Token: 0x0400EC2A RID: 60458
		private int method_p1;

		// Token: 0x0400EC2B RID: 60459
		private int method_p2;

		// Token: 0x0400EC2C RID: 60460
		private int method_p3;

		// Token: 0x0400EC2D RID: 60461
		private int method_p4;
	}
}
