using System;

namespace behaviac
{
	// Token: 0x02003062 RID: 12386
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node11 : Action
	{
		// Token: 0x0601498A RID: 84362 RVA: 0x006337C5 File Offset: 0x00631BC5
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FOLLOW;
		}

		// Token: 0x0601498B RID: 84363 RVA: 0x006337DB File Offset: 0x00631BDB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2E9 RID: 58089
		private DestinationType method_p0;
	}
}
