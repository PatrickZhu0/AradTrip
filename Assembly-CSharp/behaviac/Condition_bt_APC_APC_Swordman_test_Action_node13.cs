using System;

namespace behaviac
{
	// Token: 0x02001DFF RID: 7679
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node13 : Condition
	{
		// Token: 0x060125B1 RID: 75185 RVA: 0x0055C6CF File Offset: 0x0055AACF
		public Condition_bt_APC_APC_Swordman_test_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x060125B2 RID: 75186 RVA: 0x0055C6E4 File Offset: 0x0055AAE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFA1 RID: 49057
		private int opl_p0;
	}
}
