using System;

namespace behaviac
{
	// Token: 0x0200219B RID: 8603
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node43 : Condition
	{
		// Token: 0x06012CC6 RID: 76998 RVA: 0x0058732B File Offset: 0x0058572B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node43()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012CC7 RID: 76999 RVA: 0x00587360 File Offset: 0x00585760
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6B8 RID: 50872
		private int opl_p0;

		// Token: 0x0400C6B9 RID: 50873
		private int opl_p1;

		// Token: 0x0400C6BA RID: 50874
		private int opl_p2;

		// Token: 0x0400C6BB RID: 50875
		private int opl_p3;
	}
}
