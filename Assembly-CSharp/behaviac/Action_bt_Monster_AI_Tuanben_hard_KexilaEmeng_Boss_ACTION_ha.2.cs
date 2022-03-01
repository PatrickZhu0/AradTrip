using System;

namespace behaviac
{
	// Token: 0x02003B8D RID: 15245
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node80 : Action
	{
		// Token: 0x06015ECA RID: 89802 RVA: 0x006A00A2 File Offset: 0x0069E4A2
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node80()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x06015ECB RID: 89803 RVA: 0x006A00B8 File Offset: 0x0069E4B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F787 RID: 63367
		private int method_p0;
	}
}
