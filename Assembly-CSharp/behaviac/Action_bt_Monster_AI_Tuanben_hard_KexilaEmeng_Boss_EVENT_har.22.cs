using System;

namespace behaviac
{
	// Token: 0x02003BED RID: 15341
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node93 : Action
	{
		// Token: 0x06015F87 RID: 89991 RVA: 0x006A31B9 File Offset: 0x006A15B9
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node93()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015F88 RID: 89992 RVA: 0x006A31CF File Offset: 0x006A15CF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F821 RID: 63521
		private int method_p0;
	}
}
