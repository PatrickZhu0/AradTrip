using System;

namespace behaviac
{
	// Token: 0x02001DF8 RID: 7672
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node2 : Condition
	{
		// Token: 0x060125A4 RID: 75172 RVA: 0x0055C409 File Offset: 0x0055A809
		public Condition_bt_APC_APC_Swordman_test_Action_node2()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060125A5 RID: 75173 RVA: 0x0055C41C File Offset: 0x0055A81C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF95 RID: 49045
		private float opl_p0;
	}
}
