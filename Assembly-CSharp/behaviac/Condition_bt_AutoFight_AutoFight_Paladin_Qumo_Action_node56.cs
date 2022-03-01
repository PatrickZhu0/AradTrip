using System;

namespace behaviac
{
	// Token: 0x020027DF RID: 10207
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node56 : Condition
	{
		// Token: 0x060138FD RID: 80125 RVA: 0x005D5302 File Offset: 0x005D3702
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node56()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060138FE RID: 80126 RVA: 0x005D5338 File Offset: 0x005D3738
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D35B RID: 54107
		private int opl_p0;

		// Token: 0x0400D35C RID: 54108
		private int opl_p1;

		// Token: 0x0400D35D RID: 54109
		private int opl_p2;

		// Token: 0x0400D35E RID: 54110
		private int opl_p3;
	}
}
