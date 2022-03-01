using System;

namespace behaviac
{
	// Token: 0x0200244F RID: 9295
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node65 : Condition
	{
		// Token: 0x060131F2 RID: 78322 RVA: 0x005AC183 File Offset: 0x005AA583
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node65()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 0;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060131F3 RID: 78323 RVA: 0x005AC1B4 File Offset: 0x005AA5B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC19 RID: 52249
		private int opl_p0;

		// Token: 0x0400CC1A RID: 52250
		private int opl_p1;

		// Token: 0x0400CC1B RID: 52251
		private int opl_p2;

		// Token: 0x0400CC1C RID: 52252
		private int opl_p3;
	}
}
