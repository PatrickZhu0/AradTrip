using System;

namespace behaviac
{
	// Token: 0x02003A8D RID: 14989
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node4 : Action
	{
		// Token: 0x06015CDF RID: 89311 RVA: 0x00696AAE File Offset: 0x00694EAE
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x06015CE0 RID: 89312 RVA: 0x00696AC4 File Offset: 0x00694EC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F617 RID: 62999
		private int method_p0;
	}
}
