using System;

namespace behaviac
{
	// Token: 0x02003168 RID: 12648
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Zhoufaqiu_Event_node2 : Action
	{
		// Token: 0x06014B6A RID: 84842 RVA: 0x0063CFEE File Offset: 0x0063B3EE
		public Action_bt_Monster_AI_Chapter10_Zhoufaqiu_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522079;
			this.method_p2 = 1000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014B6B RID: 84843 RVA: 0x0063D029 File Offset: 0x0063B429
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4E4 RID: 58596
		private BE_Target method_p0;

		// Token: 0x0400E4E5 RID: 58597
		private int method_p1;

		// Token: 0x0400E4E6 RID: 58598
		private int method_p2;

		// Token: 0x0400E4E7 RID: 58599
		private int method_p3;

		// Token: 0x0400E4E8 RID: 58600
		private int method_p4;
	}
}
