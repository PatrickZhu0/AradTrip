using System;

namespace behaviac
{
	// Token: 0x02003A92 RID: 14994
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node1 : Action
	{
		// Token: 0x06015CE9 RID: 89321 RVA: 0x00696BCA File Offset: 0x00694FCA
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570107;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015CEA RID: 89322 RVA: 0x00696C01 File Offset: 0x00695001
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F61E RID: 63006
		private BE_Target method_p0;

		// Token: 0x0400F61F RID: 63007
		private int method_p1;

		// Token: 0x0400F620 RID: 63008
		private int method_p2;

		// Token: 0x0400F621 RID: 63009
		private int method_p3;

		// Token: 0x0400F622 RID: 63010
		private int method_p4;
	}
}
