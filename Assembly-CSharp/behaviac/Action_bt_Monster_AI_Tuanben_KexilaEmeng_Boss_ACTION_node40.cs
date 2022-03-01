using System;

namespace behaviac
{
	// Token: 0x020039D7 RID: 14807
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node40 : Action
	{
		// Token: 0x06015B7E RID: 88958 RVA: 0x0068F33A File Offset: 0x0068D73A
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node40()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 1;
		}

		// Token: 0x06015B7F RID: 88959 RVA: 0x0068F357 File Offset: 0x0068D757
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4C6 RID: 62662
		private int method_p0;

		// Token: 0x0400F4C7 RID: 62663
		private int method_p1;
	}
}
