using System;

namespace behaviac
{
	// Token: 0x0200337B RID: 13179
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node20 : Action
	{
		// Token: 0x06014F53 RID: 85843 RVA: 0x00650814 File Offset: 0x0064EC14
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node20()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521404;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F54 RID: 85844 RVA: 0x0065084C File Offset: 0x0064EC4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E81A RID: 59418
		private BE_Target method_p0;

		// Token: 0x0400E81B RID: 59419
		private int method_p1;

		// Token: 0x0400E81C RID: 59420
		private int method_p2;

		// Token: 0x0400E81D RID: 59421
		private int method_p3;

		// Token: 0x0400E81E RID: 59422
		private int method_p4;
	}
}
