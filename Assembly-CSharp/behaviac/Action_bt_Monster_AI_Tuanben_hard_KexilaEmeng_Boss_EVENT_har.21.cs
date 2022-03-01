using System;

namespace behaviac
{
	// Token: 0x02003BEB RID: 15339
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node13 : Action
	{
		// Token: 0x06015F83 RID: 89987 RVA: 0x006A311F File Offset: 0x006A151F
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570149;
			this.method_p2 = 0;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06015F84 RID: 89988 RVA: 0x006A3155 File Offset: 0x006A1555
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F81C RID: 63516
		private BE_Target method_p0;

		// Token: 0x0400F81D RID: 63517
		private int method_p1;

		// Token: 0x0400F81E RID: 63518
		private int method_p2;

		// Token: 0x0400F81F RID: 63519
		private int method_p3;

		// Token: 0x0400F820 RID: 63520
		private int method_p4;
	}
}
