using System;

namespace behaviac
{
	// Token: 0x02001DFB RID: 7675
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node6 : Condition
	{
		// Token: 0x060125AA RID: 75178 RVA: 0x0055C59E File Offset: 0x0055A99E
		public Condition_bt_APC_APC_Swordman_test_Action_node6()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060125AB RID: 75179 RVA: 0x0055C5D4 File Offset: 0x0055A9D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF99 RID: 49049
		private int opl_p0;

		// Token: 0x0400BF9A RID: 49050
		private int opl_p1;

		// Token: 0x0400BF9B RID: 49051
		private int opl_p2;

		// Token: 0x0400BF9C RID: 49052
		private int opl_p3;
	}
}
