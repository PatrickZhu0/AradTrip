using System;

namespace behaviac
{
	// Token: 0x02003BFA RID: 15354
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node18 : Action
	{
		// Token: 0x06015FA1 RID: 90017 RVA: 0x006A3482 File Offset: 0x006A1882
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015FA2 RID: 90018 RVA: 0x006A3498 File Offset: 0x006A1898
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F82B RID: 63531
		private int method_p0;
	}
}
