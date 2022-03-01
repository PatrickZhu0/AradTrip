using System;

namespace behaviac
{
	// Token: 0x020026D5 RID: 9941
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node103 : Action
	{
		// Token: 0x060136ED RID: 79597 RVA: 0x005C960A File Offset: 0x005C7A0A
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node103()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 6000;
			this.method_p1 = 1000;
			this.method_p2 = 4000;
			this.method_p3 = 4000;
		}

		// Token: 0x060136EE RID: 79598 RVA: 0x005C9645 File Offset: 0x005C7A45
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D143 RID: 53571
		private int method_p0;

		// Token: 0x0400D144 RID: 53572
		private int method_p1;

		// Token: 0x0400D145 RID: 53573
		private int method_p2;

		// Token: 0x0400D146 RID: 53574
		private int method_p3;
	}
}
