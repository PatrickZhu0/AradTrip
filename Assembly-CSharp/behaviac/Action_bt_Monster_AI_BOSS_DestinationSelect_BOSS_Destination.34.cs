using System;

namespace behaviac
{
	// Token: 0x02003011 RID: 12305
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node11 : Action
	{
		// Token: 0x060148EB RID: 84203 RVA: 0x006304DD File Offset: 0x0062E8DD
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x060148EC RID: 84204 RVA: 0x006304F3 File Offset: 0x0062E8F3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E24A RID: 57930
		private DestinationType method_p0;
	}
}
