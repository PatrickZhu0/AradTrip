using System;

namespace behaviac
{
	// Token: 0x020039F9 RID: 14841
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node13 : Action
	{
		// Token: 0x06015BC0 RID: 89024 RVA: 0x00690B57 File Offset: 0x0068EF57
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570149;
			this.method_p2 = 0;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06015BC1 RID: 89025 RVA: 0x00690B8D File Offset: 0x0068EF8D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4F1 RID: 62705
		private BE_Target method_p0;

		// Token: 0x0400F4F2 RID: 62706
		private int method_p1;

		// Token: 0x0400F4F3 RID: 62707
		private int method_p2;

		// Token: 0x0400F4F4 RID: 62708
		private int method_p3;

		// Token: 0x0400F4F5 RID: 62709
		private int method_p4;
	}
}
