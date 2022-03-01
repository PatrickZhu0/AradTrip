using System;

namespace behaviac
{
	// Token: 0x02003E96 RID: 16022
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node13 : Action
	{
		// Token: 0x060164AC RID: 91308 RVA: 0x006BDB57 File Offset: 0x006BBF57
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060164AD RID: 91309 RVA: 0x006BDB6D File Offset: 0x006BBF6D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCE5 RID: 64741
		private DestinationType method_p0;
	}
}
