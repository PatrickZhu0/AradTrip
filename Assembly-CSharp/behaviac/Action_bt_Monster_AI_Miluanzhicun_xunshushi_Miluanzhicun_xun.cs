using System;

namespace behaviac
{
	// Token: 0x020035CB RID: 13771
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node7 : Action
	{
		// Token: 0x060153C0 RID: 86976 RVA: 0x0066697D File Offset: 0x00664D7D
		public Action_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x060153C1 RID: 86977 RVA: 0x00666993 File Offset: 0x00664D93
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED85 RID: 60805
		private DestinationType method_p0;
	}
}
