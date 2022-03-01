using System;

namespace behaviac
{
	// Token: 0x02001EC5 RID: 7877
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node5 : Condition
	{
		// Token: 0x06012731 RID: 75569 RVA: 0x00565A61 File Offset: 0x00563E61
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012732 RID: 75570 RVA: 0x00565A74 File Offset: 0x00563E74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C11F RID: 49439
		private float opl_p0;
	}
}
