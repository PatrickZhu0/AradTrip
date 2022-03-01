using System;

namespace behaviac
{
	// Token: 0x02001D79 RID: 7545
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node11 : Condition
	{
		// Token: 0x060124AE RID: 74926 RVA: 0x005566E1 File Offset: 0x00554AE1
		public Condition_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node11()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060124AF RID: 74927 RVA: 0x005566F4 File Offset: 0x00554AF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE9C RID: 48796
		private float opl_p0;
	}
}
