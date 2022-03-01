using System;

namespace behaviac
{
	// Token: 0x02003392 RID: 13202
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node32 : Action
	{
		// Token: 0x06014F81 RID: 85889 RVA: 0x00650FBE File Offset: 0x0064F3BE
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node32()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521399;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F82 RID: 85890 RVA: 0x00650FF6 File Offset: 0x0064F3F6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E859 RID: 59481
		private BE_Target method_p0;

		// Token: 0x0400E85A RID: 59482
		private int method_p1;

		// Token: 0x0400E85B RID: 59483
		private int method_p2;

		// Token: 0x0400E85C RID: 59484
		private int method_p3;

		// Token: 0x0400E85D RID: 59485
		private int method_p4;
	}
}
