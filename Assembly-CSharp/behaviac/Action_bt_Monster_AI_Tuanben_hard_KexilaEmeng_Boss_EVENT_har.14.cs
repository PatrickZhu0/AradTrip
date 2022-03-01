using System;

namespace behaviac
{
	// Token: 0x02003BDB RID: 15323
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node67 : Action
	{
		// Token: 0x06015F63 RID: 89955 RVA: 0x006A2CB5 File Offset: 0x006A10B5
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node67()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "贝希摩斯之心已被击破，超级强化将消除。";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06015F64 RID: 89956 RVA: 0x006A2CE1 File Offset: 0x006A10E1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7FE RID: 63486
		private string method_p0;

		// Token: 0x0400F7FF RID: 63487
		private float method_p1;

		// Token: 0x0400F800 RID: 63488
		private int method_p2;
	}
}
