using System;

namespace behaviac
{
	// Token: 0x02003A06 RID: 14854
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node16 : Action
	{
		// Token: 0x06015BDA RID: 89050 RVA: 0x00690E5D File Offset: 0x0068F25D
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 3;
		}

		// Token: 0x06015BDB RID: 89051 RVA: 0x00690E7A File Offset: 0x0068F27A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4FE RID: 62718
		private int method_p0;

		// Token: 0x0400F4FF RID: 62719
		private int method_p1;
	}
}
