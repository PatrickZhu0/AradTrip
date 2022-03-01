using System;

namespace behaviac
{
	// Token: 0x02003556 RID: 13654
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node6 : Action
	{
		// Token: 0x060152EA RID: 86762 RVA: 0x00662695 File Offset: 0x00660A95
		public Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060152EB RID: 86763 RVA: 0x006626AB File Offset: 0x00660AAB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECA0 RID: 60576
		private DestinationType method_p0;
	}
}
