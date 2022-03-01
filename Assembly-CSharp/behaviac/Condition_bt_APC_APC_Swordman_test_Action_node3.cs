using System;

namespace behaviac
{
	// Token: 0x02001DF9 RID: 7673
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node3 : Condition
	{
		// Token: 0x060125A6 RID: 75174 RVA: 0x0055C44F File Offset: 0x0055A84F
		public Condition_bt_APC_APC_Swordman_test_Action_node3()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x060125A7 RID: 75175 RVA: 0x0055C464 File Offset: 0x0055A864
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF96 RID: 49046
		private int opl_p0;
	}
}
