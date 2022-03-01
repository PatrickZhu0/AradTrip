using System;

namespace behaviac
{
	// Token: 0x0200295F RID: 10591
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node30 : Action
	{
		// Token: 0x06013BF3 RID: 80883 RVA: 0x005E7726 File Offset: 0x005E5B26
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 6000;
			this.method_p1 = 1000;
			this.method_p2 = 3000;
			this.method_p3 = 3000;
		}

		// Token: 0x06013BF4 RID: 80884 RVA: 0x005E7761 File Offset: 0x005E5B61
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D658 RID: 54872
		private int method_p0;

		// Token: 0x0400D659 RID: 54873
		private int method_p1;

		// Token: 0x0400D65A RID: 54874
		private int method_p2;

		// Token: 0x0400D65B RID: 54875
		private int method_p3;
	}
}
