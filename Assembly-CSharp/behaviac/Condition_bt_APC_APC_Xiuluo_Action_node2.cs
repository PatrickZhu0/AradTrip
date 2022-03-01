using System;

namespace behaviac
{
	// Token: 0x02001E31 RID: 7729
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Xiuluo_Action_node2 : Condition
	{
		// Token: 0x06012610 RID: 75280 RVA: 0x0055EADE File Offset: 0x0055CEDE
		public Condition_bt_APC_APC_Xiuluo_Action_node2()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012611 RID: 75281 RVA: 0x0055EB14 File Offset: 0x0055CF14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFF5 RID: 49141
		private int opl_p0;

		// Token: 0x0400BFF6 RID: 49142
		private int opl_p1;

		// Token: 0x0400BFF7 RID: 49143
		private int opl_p2;

		// Token: 0x0400BFF8 RID: 49144
		private int opl_p3;
	}
}
