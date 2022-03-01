using System;

namespace behaviac
{
	// Token: 0x02003E9B RID: 16027
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node29 : Action
	{
		// Token: 0x060164B6 RID: 91318 RVA: 0x006BDCB3 File Offset: 0x006BC0B3
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x060164B7 RID: 91319 RVA: 0x006BDCC9 File Offset: 0x006BC0C9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCED RID: 64749
		private DestinationType method_p0;
	}
}
