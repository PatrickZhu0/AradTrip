using System;

namespace behaviac
{
	// Token: 0x02001E7E RID: 7806
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node23 : Condition
	{
		// Token: 0x060126A7 RID: 75431 RVA: 0x0056277A File Offset: 0x00560B7A
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node23()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060126A8 RID: 75432 RVA: 0x005627AC File Offset: 0x00560BAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C08E RID: 49294
		private int opl_p0;

		// Token: 0x0400C08F RID: 49295
		private int opl_p1;

		// Token: 0x0400C090 RID: 49296
		private int opl_p2;

		// Token: 0x0400C091 RID: 49297
		private int opl_p3;
	}
}
