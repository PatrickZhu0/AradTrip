using System;

namespace behaviac
{
	// Token: 0x02003BF8 RID: 15352
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node16 : Action
	{
		// Token: 0x06015F9D RID: 90013 RVA: 0x006A3425 File Offset: 0x006A1825
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 3;
		}

		// Token: 0x06015F9E RID: 90014 RVA: 0x006A3442 File Offset: 0x006A1842
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F829 RID: 63529
		private int method_p0;

		// Token: 0x0400F82A RID: 63530
		private int method_p1;
	}
}
