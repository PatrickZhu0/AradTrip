using System;

namespace behaviac
{
	// Token: 0x0200302C RID: 12332
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node11 : Action
	{
		// Token: 0x06014920 RID: 84256 RVA: 0x006315D5 File Offset: 0x0062F9D5
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x06014921 RID: 84257 RVA: 0x006315EB File Offset: 0x0062F9EB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E27F RID: 57983
		private DestinationType method_p0;
	}
}
