using System;

namespace behaviac
{
	// Token: 0x02003E94 RID: 16020
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node25 : Action
	{
		// Token: 0x060164A8 RID: 91304 RVA: 0x006BDAE7 File Offset: 0x006BBEE7
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060164A9 RID: 91305 RVA: 0x006BDAFD File Offset: 0x006BBEFD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCE3 RID: 64739
		private DestinationType method_p0;
	}
}
