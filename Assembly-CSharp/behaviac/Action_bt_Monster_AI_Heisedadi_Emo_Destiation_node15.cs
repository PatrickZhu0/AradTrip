using System;

namespace behaviac
{
	// Token: 0x02003401 RID: 13313
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node15 : Action
	{
		// Token: 0x06015054 RID: 86100 RVA: 0x006553DB File Offset: 0x006537DB
		public Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06015055 RID: 86101 RVA: 0x006553F1 File Offset: 0x006537F1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E936 RID: 59702
		private DestinationType method_p0;
	}
}
