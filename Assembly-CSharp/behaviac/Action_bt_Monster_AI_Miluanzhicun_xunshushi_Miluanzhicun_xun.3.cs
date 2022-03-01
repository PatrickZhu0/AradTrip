using System;

namespace behaviac
{
	// Token: 0x020035D1 RID: 13777
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node11 : Action
	{
		// Token: 0x060153CC RID: 86988 RVA: 0x00666B55 File Offset: 0x00664F55
		public Action_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x060153CD RID: 86989 RVA: 0x00666B6B File Offset: 0x00664F6B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED91 RID: 60817
		private DestinationType method_p0;
	}
}
