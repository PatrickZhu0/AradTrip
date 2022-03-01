using System;

namespace behaviac
{
	// Token: 0x02001EC7 RID: 7879
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node13 : Condition
	{
		// Token: 0x06012735 RID: 75573 RVA: 0x00565AD1 File Offset: 0x00563ED1
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node13()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012736 RID: 75574 RVA: 0x00565B08 File Offset: 0x00563F08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C121 RID: 49441
		private int opl_p0;

		// Token: 0x0400C122 RID: 49442
		private int opl_p1;

		// Token: 0x0400C123 RID: 49443
		private int opl_p2;

		// Token: 0x0400C124 RID: 49444
		private int opl_p3;
	}
}
