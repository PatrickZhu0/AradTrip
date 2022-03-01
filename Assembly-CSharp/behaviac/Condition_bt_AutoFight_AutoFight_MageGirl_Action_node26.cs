using System;

namespace behaviac
{
	// Token: 0x020026A0 RID: 9888
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node26 : Condition
	{
		// Token: 0x06013684 RID: 79492 RVA: 0x005C71E2 File Offset: 0x005C55E2
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node26()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013685 RID: 79493 RVA: 0x005C7218 File Offset: 0x005C5618
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0D7 RID: 53463
		private int opl_p0;

		// Token: 0x0400D0D8 RID: 53464
		private int opl_p1;

		// Token: 0x0400D0D9 RID: 53465
		private int opl_p2;

		// Token: 0x0400D0DA RID: 53466
		private int opl_p3;
	}
}
