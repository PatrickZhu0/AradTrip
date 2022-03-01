using System;

namespace behaviac
{
	// Token: 0x02001D49 RID: 7497
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Gunman_test_DestinationSelect_node6 : Condition
	{
		// Token: 0x06012452 RID: 74834 RVA: 0x00554765 File Offset: 0x00552B65
		public Condition_bt_APC_APC_Gunman_test_DestinationSelect_node6()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012453 RID: 74835 RVA: 0x00554778 File Offset: 0x00552B78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE44 RID: 48708
		private float opl_p0;
	}
}
