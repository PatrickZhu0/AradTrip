using System;

namespace behaviac
{
	// Token: 0x02003A0F RID: 14863
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node24 : Action
	{
		// Token: 0x06015BEB RID: 89067 RVA: 0x00691052 File Offset: 0x0068F452
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
		}

		// Token: 0x06015BEC RID: 89068 RVA: 0x00691068 File Offset: 0x0068F468
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F50A RID: 62730
		private int method_p0;
	}
}
