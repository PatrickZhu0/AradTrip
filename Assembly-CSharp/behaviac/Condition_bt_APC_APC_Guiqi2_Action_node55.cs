using System;

namespace behaviac
{
	// Token: 0x02001D25 RID: 7461
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node55 : Condition
	{
		// Token: 0x0601240D RID: 74765 RVA: 0x0055228F File Offset: 0x0055068F
		public Condition_bt_APC_APC_Guiqi2_Action_node55()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601240E RID: 74766 RVA: 0x005522C4 File Offset: 0x005506C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDFB RID: 48635
		private int opl_p0;

		// Token: 0x0400BDFC RID: 48636
		private int opl_p1;

		// Token: 0x0400BDFD RID: 48637
		private int opl_p2;

		// Token: 0x0400BDFE RID: 48638
		private int opl_p3;
	}
}
