using System;

namespace behaviac
{
	// Token: 0x0200215F RID: 8543
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node18 : Condition
	{
		// Token: 0x06012C4F RID: 76879 RVA: 0x00584B47 File Offset: 0x00582F47
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012C50 RID: 76880 RVA: 0x00584B7C File Offset: 0x00582F7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C641 RID: 50753
		private int opl_p0;

		// Token: 0x0400C642 RID: 50754
		private int opl_p1;

		// Token: 0x0400C643 RID: 50755
		private int opl_p2;

		// Token: 0x0400C644 RID: 50756
		private int opl_p3;
	}
}
