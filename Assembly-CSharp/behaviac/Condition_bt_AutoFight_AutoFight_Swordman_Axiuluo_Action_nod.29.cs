using System;

namespace behaviac
{
	// Token: 0x020028BD RID: 10429
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node45 : Condition
	{
		// Token: 0x06013AB4 RID: 80564 RVA: 0x005DF743 File Offset: 0x005DDB43
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node45()
		{
			this.opl_p0 = 1716;
		}

		// Token: 0x06013AB5 RID: 80565 RVA: 0x005DF758 File Offset: 0x005DDB58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D513 RID: 54547
		private int opl_p0;
	}
}
