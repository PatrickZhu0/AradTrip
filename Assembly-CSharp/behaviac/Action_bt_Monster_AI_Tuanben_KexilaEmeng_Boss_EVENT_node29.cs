using System;

namespace behaviac
{
	// Token: 0x02003A0B RID: 14859
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node29 : Action
	{
		// Token: 0x06015BE3 RID: 89059 RVA: 0x00690F6B File Offset: 0x0068F36B
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570151;
		}

		// Token: 0x06015BE4 RID: 89060 RVA: 0x00690F8C File Offset: 0x0068F38C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F504 RID: 62724
		private BE_Target method_p0;

		// Token: 0x0400F505 RID: 62725
		private int method_p1;
	}
}
