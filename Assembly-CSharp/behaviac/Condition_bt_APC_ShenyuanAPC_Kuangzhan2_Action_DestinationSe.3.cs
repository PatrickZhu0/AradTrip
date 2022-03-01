using System;

namespace behaviac
{
	// Token: 0x02001E76 RID: 7798
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node48 : Condition
	{
		// Token: 0x06012697 RID: 75415 RVA: 0x00562431 File Offset: 0x00560831
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node48()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012698 RID: 75416 RVA: 0x00562444 File Offset: 0x00560844
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C07F RID: 49279
		private float opl_p0;
	}
}
