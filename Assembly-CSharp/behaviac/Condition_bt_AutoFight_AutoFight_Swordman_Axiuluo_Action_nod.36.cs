using System;

namespace behaviac
{
	// Token: 0x020028C6 RID: 10438
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node57 : Condition
	{
		// Token: 0x06013AC6 RID: 80582 RVA: 0x005DFB69 File Offset: 0x005DDF69
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node57()
		{
			this.opl_p0 = 1700;
		}

		// Token: 0x06013AC7 RID: 80583 RVA: 0x005DFB7C File Offset: 0x005DDF7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D526 RID: 54566
		private int opl_p0;
	}
}
