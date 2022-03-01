using System;

namespace behaviac
{
	// Token: 0x02001E08 RID: 7688
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node26 : Condition
	{
		// Token: 0x060125C3 RID: 75203 RVA: 0x0055CBFA File Offset: 0x0055AFFA
		public Condition_bt_APC_APC_Swordman_test_Action_node26()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060125C4 RID: 75204 RVA: 0x0055CC30 File Offset: 0x0055B030
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFAE RID: 49070
		private int opl_p0;

		// Token: 0x0400BFAF RID: 49071
		private int opl_p1;

		// Token: 0x0400BFB0 RID: 49072
		private int opl_p2;

		// Token: 0x0400BFB1 RID: 49073
		private int opl_p3;
	}
}
