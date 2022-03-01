using System;

namespace behaviac
{
	// Token: 0x0200302F RID: 12335
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node15 : Action
	{
		// Token: 0x06014926 RID: 84262 RVA: 0x006316C1 File Offset: 0x0062FAC1
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06014927 RID: 84263 RVA: 0x006316D7 File Offset: 0x0062FAD7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E285 RID: 57989
		private DestinationType method_p0;
	}
}
