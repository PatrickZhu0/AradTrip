using System;

namespace behaviac
{
	// Token: 0x02001D43 RID: 7491
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Gunman_test_Action_node8 : Condition
	{
		// Token: 0x06012447 RID: 74823 RVA: 0x005542E9 File Offset: 0x005526E9
		public Condition_bt_APC_APC_Gunman_test_Action_node8()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012448 RID: 74824 RVA: 0x00554320 File Offset: 0x00552720
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE39 RID: 48697
		private int opl_p0;

		// Token: 0x0400BE3A RID: 48698
		private int opl_p1;

		// Token: 0x0400BE3B RID: 48699
		private int opl_p2;

		// Token: 0x0400BE3C RID: 48700
		private int opl_p3;
	}
}
