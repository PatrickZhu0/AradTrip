using System;

namespace behaviac
{
	// Token: 0x02002F45 RID: 12101
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node9 : Condition
	{
		// Token: 0x0601475A RID: 83802 RVA: 0x00627EB2 File Offset: 0x006262B2
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node9()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601475B RID: 83803 RVA: 0x00627EE8 File Offset: 0x006262E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0C9 RID: 57545
		private int opl_p0;

		// Token: 0x0400E0CA RID: 57546
		private int opl_p1;

		// Token: 0x0400E0CB RID: 57547
		private int opl_p2;

		// Token: 0x0400E0CC RID: 57548
		private int opl_p3;
	}
}
