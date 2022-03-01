using System;

namespace behaviac
{
	// Token: 0x02001E7F RID: 7807
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node26 : Condition
	{
		// Token: 0x060126A9 RID: 75433 RVA: 0x005627F1 File Offset: 0x00560BF1
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node26()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060126AA RID: 75434 RVA: 0x00562804 File Offset: 0x00560C04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C092 RID: 49298
		private float opl_p0;
	}
}
