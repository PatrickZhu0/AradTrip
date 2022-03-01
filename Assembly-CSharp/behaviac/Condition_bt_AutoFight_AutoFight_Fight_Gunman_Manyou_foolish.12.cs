using System;

namespace behaviac
{
	// Token: 0x0200213F RID: 8511
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node28 : Condition
	{
		// Token: 0x06012C10 RID: 76816 RVA: 0x00583113 File Offset: 0x00581513
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node28()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x06012C11 RID: 76817 RVA: 0x00583148 File Offset: 0x00581548
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C602 RID: 50690
		private int opl_p0;

		// Token: 0x0400C603 RID: 50691
		private int opl_p1;

		// Token: 0x0400C604 RID: 50692
		private int opl_p2;

		// Token: 0x0400C605 RID: 50693
		private int opl_p3;
	}
}
