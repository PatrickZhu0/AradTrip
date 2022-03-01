using System;

namespace behaviac
{
	// Token: 0x02001EC9 RID: 7881
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node15 : Condition
	{
		// Token: 0x06012739 RID: 75577 RVA: 0x00565B7A File Offset: 0x00563F7A
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node15()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601273A RID: 75578 RVA: 0x00565BB0 File Offset: 0x00563FB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C126 RID: 49446
		private int opl_p0;

		// Token: 0x0400C127 RID: 49447
		private int opl_p1;

		// Token: 0x0400C128 RID: 49448
		private int opl_p2;

		// Token: 0x0400C129 RID: 49449
		private int opl_p3;
	}
}
