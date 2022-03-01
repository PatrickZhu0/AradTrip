using System;

namespace behaviac
{
	// Token: 0x02002F62 RID: 12130
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node24 : Condition
	{
		// Token: 0x06014793 RID: 83859 RVA: 0x00628FEA File Offset: 0x006273EA
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node24()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014794 RID: 83860 RVA: 0x00629020 File Offset: 0x00627420
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E101 RID: 57601
		private int opl_p0;

		// Token: 0x0400E102 RID: 57602
		private int opl_p1;

		// Token: 0x0400E103 RID: 57603
		private int opl_p2;

		// Token: 0x0400E104 RID: 57604
		private int opl_p3;
	}
}
