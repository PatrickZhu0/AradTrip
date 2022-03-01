using System;

namespace behaviac
{
	// Token: 0x02001E82 RID: 7810
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node3 : Condition
	{
		// Token: 0x060126AF RID: 75439 RVA: 0x0056292A File Offset: 0x00560D2A
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node3()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060126B0 RID: 75440 RVA: 0x00562960 File Offset: 0x00560D60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C096 RID: 49302
		private int opl_p0;

		// Token: 0x0400C097 RID: 49303
		private int opl_p1;

		// Token: 0x0400C098 RID: 49304
		private int opl_p2;

		// Token: 0x0400C099 RID: 49305
		private int opl_p3;
	}
}
