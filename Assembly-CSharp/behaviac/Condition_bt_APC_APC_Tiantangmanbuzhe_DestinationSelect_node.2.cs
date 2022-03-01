using System;

namespace behaviac
{
	// Token: 0x02001E28 RID: 7720
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node5 : Condition
	{
		// Token: 0x06012600 RID: 75264 RVA: 0x0055E595 File Offset: 0x0055C995
		public Condition_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node5()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x06012601 RID: 75265 RVA: 0x0055E5A8 File Offset: 0x0055C9A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFEA RID: 49130
		private float opl_p0;
	}
}
