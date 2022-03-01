using System;

namespace behaviac
{
	// Token: 0x02002F6A RID: 12138
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node34 : Condition
	{
		// Token: 0x060147A3 RID: 83875 RVA: 0x00629352 File Offset: 0x00627752
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node34()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060147A4 RID: 83876 RVA: 0x00629388 File Offset: 0x00627788
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E111 RID: 57617
		private int opl_p0;

		// Token: 0x0400E112 RID: 57618
		private int opl_p1;

		// Token: 0x0400E113 RID: 57619
		private int opl_p2;

		// Token: 0x0400E114 RID: 57620
		private int opl_p3;
	}
}
