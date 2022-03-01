using System;

namespace behaviac
{
	// Token: 0x0200361A RID: 13850
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node19 : Action
	{
		// Token: 0x06015459 RID: 87129 RVA: 0x00669C49 File Offset: 0x00668049
		public Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601545A RID: 87130 RVA: 0x00669C5F File Offset: 0x0066805F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE14 RID: 60948
		private DestinationType method_p0;
	}
}
