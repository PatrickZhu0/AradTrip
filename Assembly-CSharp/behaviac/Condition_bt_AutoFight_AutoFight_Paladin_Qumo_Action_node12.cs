using System;

namespace behaviac
{
	// Token: 0x020027BB RID: 10171
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node12 : Condition
	{
		// Token: 0x060138B5 RID: 80053 RVA: 0x005D43AE File Offset: 0x005D27AE
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node12()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060138B6 RID: 80054 RVA: 0x005D43E4 File Offset: 0x005D27E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D313 RID: 54035
		private int opl_p0;

		// Token: 0x0400D314 RID: 54036
		private int opl_p1;

		// Token: 0x0400D315 RID: 54037
		private int opl_p2;

		// Token: 0x0400D316 RID: 54038
		private int opl_p3;
	}
}
