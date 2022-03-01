using System;

namespace behaviac
{
	// Token: 0x020024B2 RID: 9394
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node27 : Condition
	{
		// Token: 0x060132AF RID: 78511 RVA: 0x005B079F File Offset: 0x005AEB9F
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node27()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060132B0 RID: 78512 RVA: 0x005B07D4 File Offset: 0x005AEBD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCC8 RID: 52424
		private int opl_p0;

		// Token: 0x0400CCC9 RID: 52425
		private int opl_p1;

		// Token: 0x0400CCCA RID: 52426
		private int opl_p2;

		// Token: 0x0400CCCB RID: 52427
		private int opl_p3;
	}
}
