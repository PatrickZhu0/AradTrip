using System;

namespace behaviac
{
	// Token: 0x020032A4 RID: 12964
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node9 : Action
	{
		// Token: 0x06014DBF RID: 85439 RVA: 0x00648753 File Offset: 0x00646B53
		public Action_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06014DC0 RID: 85440 RVA: 0x00648769 File Offset: 0x00646B69
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6AF RID: 59055
		private DestinationType method_p0;
	}
}
