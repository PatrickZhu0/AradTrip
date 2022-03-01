using System;

namespace behaviac
{
	// Token: 0x0200296C RID: 10604
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node18 : Action
	{
		// Token: 0x06013C0D RID: 80909 RVA: 0x005E7C7A File Offset: 0x005E607A
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 6000;
			this.method_p1 = 3000;
			this.method_p2 = 3000;
			this.method_p3 = 3000;
		}

		// Token: 0x06013C0E RID: 80910 RVA: 0x005E7CB5 File Offset: 0x005E60B5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D672 RID: 54898
		private int method_p0;

		// Token: 0x0400D673 RID: 54899
		private int method_p1;

		// Token: 0x0400D674 RID: 54900
		private int method_p2;

		// Token: 0x0400D675 RID: 54901
		private int method_p3;
	}
}
