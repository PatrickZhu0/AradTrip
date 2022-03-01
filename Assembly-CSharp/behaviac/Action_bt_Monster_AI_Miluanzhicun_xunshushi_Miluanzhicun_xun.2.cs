using System;

namespace behaviac
{
	// Token: 0x020035CE RID: 13774
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node19 : Action
	{
		// Token: 0x060153C6 RID: 86982 RVA: 0x00666A69 File Offset: 0x00664E69
		public Action_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x060153C7 RID: 86983 RVA: 0x00666A7F File Offset: 0x00664E7F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED8B RID: 60811
		private DestinationType method_p0;
	}
}
