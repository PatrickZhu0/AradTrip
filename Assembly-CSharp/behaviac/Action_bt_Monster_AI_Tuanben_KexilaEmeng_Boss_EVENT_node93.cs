using System;

namespace behaviac
{
	// Token: 0x020039FB RID: 14843
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node93 : Action
	{
		// Token: 0x06015BC4 RID: 89028 RVA: 0x00690BF1 File Offset: 0x0068EFF1
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node93()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015BC5 RID: 89029 RVA: 0x00690C07 File Offset: 0x0068F007
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4F6 RID: 62710
		private int method_p0;
	}
}
