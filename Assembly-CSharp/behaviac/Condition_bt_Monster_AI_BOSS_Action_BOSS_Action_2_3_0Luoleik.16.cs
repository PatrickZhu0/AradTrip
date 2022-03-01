using System;

namespace behaviac
{
	// Token: 0x02002F66 RID: 12134
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node29 : Condition
	{
		// Token: 0x0601479B RID: 83867 RVA: 0x0062919E File Offset: 0x0062759E
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node29()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601479C RID: 83868 RVA: 0x006291D4 File Offset: 0x006275D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E109 RID: 57609
		private int opl_p0;

		// Token: 0x0400E10A RID: 57610
		private int opl_p1;

		// Token: 0x0400E10B RID: 57611
		private int opl_p2;

		// Token: 0x0400E10C RID: 57612
		private int opl_p3;
	}
}
