using System;

namespace behaviac
{
	// Token: 0x02003032 RID: 12338
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node19 : Action
	{
		// Token: 0x0601492C RID: 84268 RVA: 0x006317AD File Offset: 0x0062FBAD
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601492D RID: 84269 RVA: 0x006317C3 File Offset: 0x0062FBC3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E28B RID: 57995
		private DestinationType method_p0;
	}
}
