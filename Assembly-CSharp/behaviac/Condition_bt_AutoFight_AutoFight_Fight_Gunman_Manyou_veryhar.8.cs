using System;

namespace behaviac
{
	// Token: 0x020021AF RID: 8623
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node18 : Condition
	{
		// Token: 0x06012CED RID: 77037 RVA: 0x0058877F File Offset: 0x00586B7F
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012CEE RID: 77038 RVA: 0x005887B4 File Offset: 0x00586BB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6DF RID: 50911
		private int opl_p0;

		// Token: 0x0400C6E0 RID: 50912
		private int opl_p1;

		// Token: 0x0400C6E1 RID: 50913
		private int opl_p2;

		// Token: 0x0400C6E2 RID: 50914
		private int opl_p3;
	}
}
