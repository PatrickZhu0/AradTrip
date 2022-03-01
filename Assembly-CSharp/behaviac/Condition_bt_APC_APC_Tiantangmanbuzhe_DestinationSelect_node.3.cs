using System;

namespace behaviac
{
	// Token: 0x02001E2A RID: 7722
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node11 : Condition
	{
		// Token: 0x06012604 RID: 75268 RVA: 0x0055E605 File Offset: 0x0055CA05
		public Condition_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node11()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06012605 RID: 75269 RVA: 0x0055E618 File Offset: 0x0055CA18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFEC RID: 49132
		private float opl_p0;
	}
}
