using System;

namespace behaviac
{
	// Token: 0x02001E75 RID: 7797
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node49 : Condition
	{
		// Token: 0x06012695 RID: 75413 RVA: 0x005623B6 File Offset: 0x005607B6
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node49()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012696 RID: 75414 RVA: 0x005623EC File Offset: 0x005607EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C07B RID: 49275
		private int opl_p0;

		// Token: 0x0400C07C RID: 49276
		private int opl_p1;

		// Token: 0x0400C07D RID: 49277
		private int opl_p2;

		// Token: 0x0400C07E RID: 49278
		private int opl_p3;
	}
}
