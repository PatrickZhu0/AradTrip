using System;

namespace behaviac
{
	// Token: 0x02003BFF RID: 15359
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node22 : Action
	{
		// Token: 0x06015FAA RID: 90026 RVA: 0x006A35A5 File Offset: 0x006A19A5
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
		}

		// Token: 0x06015FAB RID: 90027 RVA: 0x006A35BB File Offset: 0x006A19BB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F833 RID: 63539
		private int method_p0;
	}
}
