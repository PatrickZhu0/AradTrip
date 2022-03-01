using System;

namespace behaviac
{
	// Token: 0x02002232 RID: 8754
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node12 : Condition
	{
		// Token: 0x06012DEE RID: 77294 RVA: 0x0058EDD6 File Offset: 0x0058D1D6
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node12()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012DEF RID: 77295 RVA: 0x0058EE0C File Offset: 0x0058D20C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7ED RID: 51181
		private int opl_p0;

		// Token: 0x0400C7EE RID: 51182
		private int opl_p1;

		// Token: 0x0400C7EF RID: 51183
		private int opl_p2;

		// Token: 0x0400C7F0 RID: 51184
		private int opl_p3;
	}
}
