using System;

namespace behaviac
{
	// Token: 0x02003A0D RID: 14861
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node22 : Action
	{
		// Token: 0x06015BE7 RID: 89063 RVA: 0x00690FDD File Offset: 0x0068F3DD
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
		}

		// Token: 0x06015BE8 RID: 89064 RVA: 0x00690FF3 File Offset: 0x0068F3F3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F508 RID: 62728
		private int method_p0;
	}
}
