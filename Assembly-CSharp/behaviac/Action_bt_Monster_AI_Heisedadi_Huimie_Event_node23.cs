using System;

namespace behaviac
{
	// Token: 0x0200343F RID: 13375
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node23 : Action
	{
		// Token: 0x060150CC RID: 86220 RVA: 0x0065749A File Offset: 0x0065589A
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2;
		}

		// Token: 0x060150CD RID: 86221 RVA: 0x006574B0 File Offset: 0x006558B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E99E RID: 59806
		private int method_p0;
	}
}
