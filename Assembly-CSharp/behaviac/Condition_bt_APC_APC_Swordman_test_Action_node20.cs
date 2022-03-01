using System;

namespace behaviac
{
	// Token: 0x02001E04 RID: 7684
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node20 : Condition
	{
		// Token: 0x060125BB RID: 75195 RVA: 0x0055C95A File Offset: 0x0055AD5A
		public Condition_bt_APC_APC_Swordman_test_Action_node20()
		{
			this.opl_p0 = 1509;
		}

		// Token: 0x060125BC RID: 75196 RVA: 0x0055C970 File Offset: 0x0055AD70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFA8 RID: 49064
		private int opl_p0;
	}
}
