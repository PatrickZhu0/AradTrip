using System;

namespace behaviac
{
	// Token: 0x0200224C RID: 8780
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node30 : Condition
	{
		// Token: 0x06012E20 RID: 77344 RVA: 0x00590CE2 File Offset: 0x0058F0E2
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node30()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012E21 RID: 77345 RVA: 0x00590D18 File Offset: 0x0058F118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C823 RID: 51235
		private int opl_p0;

		// Token: 0x0400C824 RID: 51236
		private int opl_p1;

		// Token: 0x0400C825 RID: 51237
		private int opl_p2;

		// Token: 0x0400C826 RID: 51238
		private int opl_p3;
	}
}
