using System;

namespace behaviac
{
	// Token: 0x02001EB6 RID: 7862
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node23 : Condition
	{
		// Token: 0x06012714 RID: 75540 RVA: 0x00564DB2 File Offset: 0x005631B2
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node23()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012715 RID: 75541 RVA: 0x00564DE8 File Offset: 0x005631E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C101 RID: 49409
		private int opl_p0;

		// Token: 0x0400C102 RID: 49410
		private int opl_p1;

		// Token: 0x0400C103 RID: 49411
		private int opl_p2;

		// Token: 0x0400C104 RID: 49412
		private int opl_p3;
	}
}
