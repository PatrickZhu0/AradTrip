using System;

namespace behaviac
{
	// Token: 0x020021C3 RID: 8643
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node43 : Condition
	{
		// Token: 0x06012D15 RID: 77077 RVA: 0x00589147 File Offset: 0x00587547
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node43()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012D16 RID: 77078 RVA: 0x0058917C File Offset: 0x0058757C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C707 RID: 50951
		private int opl_p0;

		// Token: 0x0400C708 RID: 50952
		private int opl_p1;

		// Token: 0x0400C709 RID: 50953
		private int opl_p2;

		// Token: 0x0400C70A RID: 50954
		private int opl_p3;
	}
}
