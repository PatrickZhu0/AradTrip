using System;

namespace behaviac
{
	// Token: 0x02003E90 RID: 16016
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node6 : Action
	{
		// Token: 0x060164A0 RID: 91296 RVA: 0x006BD97B File Offset: 0x006BBD7B
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060164A1 RID: 91297 RVA: 0x006BD991 File Offset: 0x006BBD91
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCD9 RID: 64729
		private DestinationType method_p0;
	}
}
