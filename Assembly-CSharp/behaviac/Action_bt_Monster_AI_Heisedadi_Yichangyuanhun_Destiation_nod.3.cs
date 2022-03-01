using System;

namespace behaviac
{
	// Token: 0x0200355A RID: 13658
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node1 : Action
	{
		// Token: 0x060152F2 RID: 86770 RVA: 0x00662777 File Offset: 0x00660B77
		public Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x060152F3 RID: 86771 RVA: 0x0066278D File Offset: 0x00660B8D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECA4 RID: 60580
		private DestinationType method_p0;
	}
}
