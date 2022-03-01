using System;

namespace behaviac
{
	// Token: 0x020028C0 RID: 10432
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node49 : Condition
	{
		// Token: 0x06013ABA RID: 80570 RVA: 0x005DF87F File Offset: 0x005DDC7F
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node49()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013ABB RID: 80571 RVA: 0x005DF8B4 File Offset: 0x005DDCB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D517 RID: 54551
		private int opl_p0;

		// Token: 0x0400D518 RID: 54552
		private int opl_p1;

		// Token: 0x0400D519 RID: 54553
		private int opl_p2;

		// Token: 0x0400D51A RID: 54554
		private int opl_p3;
	}
}
