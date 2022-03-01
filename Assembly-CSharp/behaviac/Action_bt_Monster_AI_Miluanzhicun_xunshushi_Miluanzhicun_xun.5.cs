using System;

namespace behaviac
{
	// Token: 0x020035D7 RID: 13783
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node31 : Action
	{
		// Token: 0x060153D8 RID: 87000 RVA: 0x00666D2D File Offset: 0x0066512D
		public Action_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060153D9 RID: 87001 RVA: 0x00666D43 File Offset: 0x00665143
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED9D RID: 60829
		private DestinationType method_p0;
	}
}
