using System;

namespace behaviac
{
	// Token: 0x020028D4 RID: 10452
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node66 : Condition
	{
		// Token: 0x06013AE2 RID: 80610 RVA: 0x005E01FB File Offset: 0x005DE5FB
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node66()
		{
			this.opl_p0 = 1511;
		}

		// Token: 0x06013AE3 RID: 80611 RVA: 0x005E0210 File Offset: 0x005DE610
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D544 RID: 54596
		private int opl_p0;
	}
}
