using System;

namespace behaviac
{
	// Token: 0x02001E0E RID: 7694
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Swordman_test_DestinationSelect_node3 : Action
	{
		// Token: 0x060125CE RID: 75214 RVA: 0x0055D50F File Offset: 0x0055B90F
		public Action_bt_APC_APC_Swordman_test_DestinationSelect_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x060125CF RID: 75215 RVA: 0x0055D525 File Offset: 0x0055B925
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFBB RID: 49083
		private DestinationType method_p0;
	}
}
