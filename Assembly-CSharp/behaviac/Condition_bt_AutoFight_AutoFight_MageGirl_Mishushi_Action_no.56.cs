using System;

namespace behaviac
{
	// Token: 0x020026FA RID: 9978
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node31 : Condition
	{
		// Token: 0x06013737 RID: 79671 RVA: 0x005CA596 File Offset: 0x005C8996
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node31()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013738 RID: 79672 RVA: 0x005CA5CC File Offset: 0x005C89CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D18D RID: 53645
		private int opl_p0;

		// Token: 0x0400D18E RID: 53646
		private int opl_p1;

		// Token: 0x0400D18F RID: 53647
		private int opl_p2;

		// Token: 0x0400D190 RID: 53648
		private int opl_p3;
	}
}
