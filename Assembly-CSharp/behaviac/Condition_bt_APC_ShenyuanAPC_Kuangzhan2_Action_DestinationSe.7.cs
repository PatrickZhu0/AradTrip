using System;

namespace behaviac
{
	// Token: 0x02001E7B RID: 7803
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node6 : Condition
	{
		// Token: 0x060126A1 RID: 75425 RVA: 0x00562641 File Offset: 0x00560A41
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node6()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060126A2 RID: 75426 RVA: 0x00562654 File Offset: 0x00560A54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C08A RID: 49290
		private float opl_p0;
	}
}
