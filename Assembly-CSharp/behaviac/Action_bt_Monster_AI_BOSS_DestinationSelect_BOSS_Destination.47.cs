using System;

namespace behaviac
{
	// Token: 0x02003038 RID: 12344
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node27 : Action
	{
		// Token: 0x06014938 RID: 84280 RVA: 0x00631985 File Offset: 0x0062FD85
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014939 RID: 84281 RVA: 0x0063199B File Offset: 0x0062FD9B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E297 RID: 58007
		private DestinationType method_p0;
	}
}
