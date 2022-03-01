using System;

namespace behaviac
{
	// Token: 0x020039FE RID: 14846
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node2 : Action
	{
		// Token: 0x06015BCA RID: 89034 RVA: 0x00690C9D File Offset: 0x0068F09D
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 1;
		}

		// Token: 0x06015BCB RID: 89035 RVA: 0x00690CBA File Offset: 0x0068F0BA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4F8 RID: 62712
		private int method_p0;

		// Token: 0x0400F4F9 RID: 62713
		private int method_p1;
	}
}
