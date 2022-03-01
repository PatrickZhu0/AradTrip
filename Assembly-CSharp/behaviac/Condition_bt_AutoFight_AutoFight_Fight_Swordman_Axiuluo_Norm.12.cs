using System;

namespace behaviac
{
	// Token: 0x0200224F RID: 8783
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node33 : Condition
	{
		// Token: 0x06012E26 RID: 77350 RVA: 0x00590E07 File Offset: 0x0058F207
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node33()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012E27 RID: 77351 RVA: 0x00590E1C File Offset: 0x0058F21C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C82B RID: 51243
		private int opl_p0;
	}
}
