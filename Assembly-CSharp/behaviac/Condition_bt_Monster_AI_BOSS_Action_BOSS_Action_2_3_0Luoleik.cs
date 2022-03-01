using System;

namespace behaviac
{
	// Token: 0x02002F52 RID: 12114
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node3 : Condition
	{
		// Token: 0x06014773 RID: 83827 RVA: 0x0062891A File Offset: 0x00626D1A
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node3()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06014774 RID: 83828 RVA: 0x00628950 File Offset: 0x00626D50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0E1 RID: 57569
		private int opl_p0;

		// Token: 0x0400E0E2 RID: 57570
		private int opl_p1;

		// Token: 0x0400E0E3 RID: 57571
		private int opl_p2;

		// Token: 0x0400E0E4 RID: 57572
		private int opl_p3;
	}
}
