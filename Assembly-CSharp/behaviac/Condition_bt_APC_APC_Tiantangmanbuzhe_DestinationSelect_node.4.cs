using System;

namespace behaviac
{
	// Token: 0x02001E2C RID: 7724
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node14 : Condition
	{
		// Token: 0x06012608 RID: 75272 RVA: 0x0055E675 File Offset: 0x0055CA75
		public Condition_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node14()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x06012609 RID: 75273 RVA: 0x0055E688 File Offset: 0x0055CA88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFEE RID: 49134
		private float opl_p0;
	}
}
