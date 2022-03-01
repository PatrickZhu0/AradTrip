using System;

namespace behaviac
{
	// Token: 0x02001E64 RID: 7780
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node6 : Condition
	{
		// Token: 0x06012674 RID: 75380 RVA: 0x005615E1 File Offset: 0x0055F9E1
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node6()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012675 RID: 75381 RVA: 0x005615F4 File Offset: 0x0055F9F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C05D RID: 49245
		private float opl_p0;
	}
}
