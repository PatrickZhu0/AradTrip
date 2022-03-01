using System;

namespace behaviac
{
	// Token: 0x02003A08 RID: 14856
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node18 : Action
	{
		// Token: 0x06015BDE RID: 89054 RVA: 0x00690EBA File Offset: 0x0068F2BA
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015BDF RID: 89055 RVA: 0x00690ED0 File Offset: 0x0068F2D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F500 RID: 62720
		private int method_p0;
	}
}
