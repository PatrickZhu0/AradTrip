using System;

namespace behaviac
{
	// Token: 0x02003035 RID: 12341
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node23 : Action
	{
		// Token: 0x06014932 RID: 84274 RVA: 0x00631899 File Offset: 0x0062FC99
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06014933 RID: 84275 RVA: 0x006318AF File Offset: 0x0062FCAF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E291 RID: 58001
		private DestinationType method_p0;
	}
}
