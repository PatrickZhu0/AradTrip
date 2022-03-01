using System;

namespace behaviac
{
	// Token: 0x02002157 RID: 8535
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node8 : Condition
	{
		// Token: 0x06012C3F RID: 76863 RVA: 0x0058475F File Offset: 0x00582B5F
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node8()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012C40 RID: 76864 RVA: 0x00584794 File Offset: 0x00582B94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C631 RID: 50737
		private int opl_p0;

		// Token: 0x0400C632 RID: 50738
		private int opl_p1;

		// Token: 0x0400C633 RID: 50739
		private int opl_p2;

		// Token: 0x0400C634 RID: 50740
		private int opl_p3;
	}
}
