using System;

namespace behaviac
{
	// Token: 0x02002899 RID: 10393
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node7 : Condition
	{
		// Token: 0x06013A6D RID: 80493 RVA: 0x005DE717 File Offset: 0x005DCB17
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node7()
		{
			this.opl_p0 = 1710;
		}

		// Token: 0x06013A6E RID: 80494 RVA: 0x005DE72C File Offset: 0x005DCB2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4C9 RID: 54473
		private int opl_p0;
	}
}
