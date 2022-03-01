using System;

namespace behaviac
{
	// Token: 0x02001DF4 RID: 7668
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_DestinationSelect_node5 : Condition
	{
		// Token: 0x0601259D RID: 75165 RVA: 0x0055C0E5 File Offset: 0x0055A4E5
		public Condition_bt_APC_APC_Nianqishi_Action_DestinationSelect_node5()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601259E RID: 75166 RVA: 0x0055C0F8 File Offset: 0x0055A4F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF92 RID: 49042
		private float opl_p0;
	}
}
