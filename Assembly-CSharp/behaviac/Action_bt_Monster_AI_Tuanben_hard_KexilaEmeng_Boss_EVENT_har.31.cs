using System;

namespace behaviac
{
	// Token: 0x02003C02 RID: 15362
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node27 : Action
	{
		// Token: 0x06015FB0 RID: 90032 RVA: 0x006A3644 File Offset: 0x006A1A44
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2;
			this.method_p1 = 0;
		}

		// Token: 0x06015FB1 RID: 90033 RVA: 0x006A3661 File Offset: 0x006A1A61
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F836 RID: 63542
		private int method_p0;

		// Token: 0x0400F837 RID: 63543
		private int method_p1;
	}
}
