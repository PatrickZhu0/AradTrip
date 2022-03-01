using System;

namespace behaviac
{
	// Token: 0x02002936 RID: 10550
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node18 : Action
	{
		// Token: 0x06013BA2 RID: 80802 RVA: 0x005E51EA File Offset: 0x005E35EA
		public Action_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 6000;
			this.method_p1 = 2000;
			this.method_p2 = 2000;
			this.method_p3 = 2000;
		}

		// Token: 0x06013BA3 RID: 80803 RVA: 0x005E5225 File Offset: 0x005E3625
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D607 RID: 54791
		private int method_p0;

		// Token: 0x0400D608 RID: 54792
		private int method_p1;

		// Token: 0x0400D609 RID: 54793
		private int method_p2;

		// Token: 0x0400D60A RID: 54794
		private int method_p3;
	}
}
