using System;

namespace behaviac
{
	// Token: 0x02002F74 RID: 12148
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node2 : Condition
	{
		// Token: 0x060147B6 RID: 83894 RVA: 0x00629FA2 File Offset: 0x006283A2
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node2()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060147B7 RID: 83895 RVA: 0x00629FD8 File Offset: 0x006283D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E121 RID: 57633
		private int opl_p0;

		// Token: 0x0400E122 RID: 57634
		private int opl_p1;

		// Token: 0x0400E123 RID: 57635
		private int opl_p2;

		// Token: 0x0400E124 RID: 57636
		private int opl_p3;
	}
}
