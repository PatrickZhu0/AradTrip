using System;

namespace behaviac
{
	// Token: 0x0200243F RID: 9279
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node16 : Condition
	{
		// Token: 0x060131D4 RID: 78292 RVA: 0x005ABB42 File Offset: 0x005A9F42
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node16()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060131D5 RID: 78293 RVA: 0x005ABB78 File Offset: 0x005A9F78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBFD RID: 52221
		private int opl_p0;

		// Token: 0x0400CBFE RID: 52222
		private int opl_p1;

		// Token: 0x0400CBFF RID: 52223
		private int opl_p2;

		// Token: 0x0400CC00 RID: 52224
		private int opl_p3;
	}
}
