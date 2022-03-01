using System;

namespace behaviac
{
	// Token: 0x020028CB RID: 10443
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node97 : Condition
	{
		// Token: 0x06013AD0 RID: 80592 RVA: 0x005DFD7B File Offset: 0x005DE17B
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node97()
		{
			this.opl_p0 = 1506;
		}

		// Token: 0x06013AD1 RID: 80593 RVA: 0x005DFD90 File Offset: 0x005DE190
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D531 RID: 54577
		private int opl_p0;
	}
}
