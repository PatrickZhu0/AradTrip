using System;

namespace behaviac
{
	// Token: 0x02001D7B RID: 7547
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node14 : Condition
	{
		// Token: 0x060124B2 RID: 74930 RVA: 0x00556751 File Offset: 0x00554B51
		public Condition_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node14()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060124B3 RID: 74931 RVA: 0x00556764 File Offset: 0x00554B64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE9E RID: 48798
		private float opl_p0;
	}
}
