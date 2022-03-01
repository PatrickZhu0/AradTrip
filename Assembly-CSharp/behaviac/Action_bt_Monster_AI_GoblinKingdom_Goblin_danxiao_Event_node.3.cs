using System;

namespace behaviac
{
	// Token: 0x0200330E RID: 13070
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node8 : Action
	{
		// Token: 0x06014E85 RID: 85637 RVA: 0x0064CB6F File Offset: 0x0064AF6F
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 1404;
			this.method_p2 = 6000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014E86 RID: 85638 RVA: 0x0064CBAA File Offset: 0x0064AFAA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E76F RID: 59247
		private BE_Target method_p0;

		// Token: 0x0400E770 RID: 59248
		private int method_p1;

		// Token: 0x0400E771 RID: 59249
		private int method_p2;

		// Token: 0x0400E772 RID: 59250
		private int method_p3;

		// Token: 0x0400E773 RID: 59251
		private int method_p4;
	}
}
