using System;

namespace behaviac
{
	// Token: 0x020035D4 RID: 13780
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node15 : Action
	{
		// Token: 0x060153D2 RID: 86994 RVA: 0x00666C41 File Offset: 0x00665041
		public Action_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x060153D3 RID: 86995 RVA: 0x00666C57 File Offset: 0x00665057
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED97 RID: 60823
		private DestinationType method_p0;
	}
}
