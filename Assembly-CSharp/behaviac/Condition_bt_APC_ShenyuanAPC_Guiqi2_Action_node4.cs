using System;

namespace behaviac
{
	// Token: 0x02001E59 RID: 7769
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node4 : Condition
	{
		// Token: 0x0601265F RID: 75359 RVA: 0x00560646 File Offset: 0x0055EA46
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node4()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012660 RID: 75360 RVA: 0x0056067C File Offset: 0x0055EA7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C046 RID: 49222
		private int opl_p0;

		// Token: 0x0400C047 RID: 49223
		private int opl_p1;

		// Token: 0x0400C048 RID: 49224
		private int opl_p2;

		// Token: 0x0400C049 RID: 49225
		private int opl_p3;
	}
}
