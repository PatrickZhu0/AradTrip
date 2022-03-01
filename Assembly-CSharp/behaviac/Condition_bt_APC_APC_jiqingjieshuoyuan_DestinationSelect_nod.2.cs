using System;

namespace behaviac
{
	// Token: 0x02001D77 RID: 7543
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node5 : Condition
	{
		// Token: 0x060124AA RID: 74922 RVA: 0x00556671 File Offset: 0x00554A71
		public Condition_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060124AB RID: 74923 RVA: 0x00556684 File Offset: 0x00554A84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE9A RID: 48794
		private float opl_p0;
	}
}
