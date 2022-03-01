using System;

namespace behaviac
{
	// Token: 0x02003617 RID: 13847
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node15 : Action
	{
		// Token: 0x06015453 RID: 87123 RVA: 0x00669B5D File Offset: 0x00667F5D
		public Action_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06015454 RID: 87124 RVA: 0x00669B73 File Offset: 0x00667F73
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE0E RID: 60942
		private DestinationType method_p0;
	}
}
