using System;

namespace behaviac
{
	// Token: 0x0200224A RID: 8778
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node17 : Condition
	{
		// Token: 0x06012E1C RID: 77340 RVA: 0x00590BF1 File Offset: 0x0058EFF1
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node17()
		{
			this.opl_p0 = 1709;
		}

		// Token: 0x06012E1D RID: 77341 RVA: 0x00590C04 File Offset: 0x0058F004
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C820 RID: 51232
		private int opl_p0;
	}
}
