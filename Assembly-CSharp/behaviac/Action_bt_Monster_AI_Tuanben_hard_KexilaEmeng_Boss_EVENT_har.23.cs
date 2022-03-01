using System;

namespace behaviac
{
	// Token: 0x02003BF0 RID: 15344
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node2 : Action
	{
		// Token: 0x06015F8D RID: 89997 RVA: 0x006A3265 File Offset: 0x006A1665
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 1;
		}

		// Token: 0x06015F8E RID: 89998 RVA: 0x006A3282 File Offset: 0x006A1682
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F823 RID: 63523
		private int method_p0;

		// Token: 0x0400F824 RID: 63524
		private int method_p1;
	}
}
