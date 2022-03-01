using System;

namespace behaviac
{
	// Token: 0x020027CF RID: 10191
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node32 : Condition
	{
		// Token: 0x060138DD RID: 80093 RVA: 0x005D4C32 File Offset: 0x005D3032
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node32()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060138DE RID: 80094 RVA: 0x005D4C68 File Offset: 0x005D3068
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D33B RID: 54075
		private int opl_p0;

		// Token: 0x0400D33C RID: 54076
		private int opl_p1;

		// Token: 0x0400D33D RID: 54077
		private int opl_p2;

		// Token: 0x0400D33E RID: 54078
		private int opl_p3;
	}
}
