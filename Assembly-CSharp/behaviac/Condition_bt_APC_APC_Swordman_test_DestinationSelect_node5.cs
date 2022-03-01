using System;

namespace behaviac
{
	// Token: 0x02001E0F RID: 7695
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_DestinationSelect_node5 : Condition
	{
		// Token: 0x060125D0 RID: 75216 RVA: 0x0055D539 File Offset: 0x0055B939
		public Condition_bt_APC_APC_Swordman_test_DestinationSelect_node5()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060125D1 RID: 75217 RVA: 0x0055D54C File Offset: 0x0055B94C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFBC RID: 49084
		private float opl_p0;
	}
}
