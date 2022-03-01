using System;

namespace behaviac
{
	// Token: 0x02001EA8 RID: 7848
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node5 : Condition
	{
		// Token: 0x060126F9 RID: 75513 RVA: 0x0056451A File Offset: 0x0056291A
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node5()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060126FA RID: 75514 RVA: 0x00564550 File Offset: 0x00562950
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0E6 RID: 49382
		private int opl_p0;

		// Token: 0x0400C0E7 RID: 49383
		private int opl_p1;

		// Token: 0x0400C0E8 RID: 49384
		private int opl_p2;

		// Token: 0x0400C0E9 RID: 49385
		private int opl_p3;
	}
}
