using System;

namespace behaviac
{
	// Token: 0x02001E06 RID: 7686
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node23 : Condition
	{
		// Token: 0x060125BF RID: 75199 RVA: 0x0055CA4E File Offset: 0x0055AE4E
		public Condition_bt_APC_APC_Swordman_test_Action_node23()
		{
			this.opl_p0 = 1509;
		}

		// Token: 0x060125C0 RID: 75200 RVA: 0x0055CA64 File Offset: 0x0055AE64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFAB RID: 49067
		private int opl_p0;
	}
}
