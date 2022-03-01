using System;

namespace behaviac
{
	// Token: 0x02003385 RID: 13189
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node25 : Action
	{
		// Token: 0x06014F67 RID: 85863 RVA: 0x00650B80 File Offset: 0x0064EF80
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521404;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F68 RID: 85864 RVA: 0x00650BB8 File Offset: 0x0064EFB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E836 RID: 59446
		private BE_Target method_p0;

		// Token: 0x0400E837 RID: 59447
		private int method_p1;

		// Token: 0x0400E838 RID: 59448
		private int method_p2;

		// Token: 0x0400E839 RID: 59449
		private int method_p3;

		// Token: 0x0400E83A RID: 59450
		private int method_p4;
	}
}
