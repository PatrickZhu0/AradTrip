using System;

namespace behaviac
{
	// Token: 0x02003017 RID: 12311
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node19 : Action
	{
		// Token: 0x060148F7 RID: 84215 RVA: 0x006306B5 File Offset: 0x0062EAB5
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060148F8 RID: 84216 RVA: 0x006306CB File Offset: 0x0062EACB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E256 RID: 57942
		private DestinationType method_p0;
	}
}
