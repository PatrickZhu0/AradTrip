using System;

namespace behaviac
{
	// Token: 0x02002F41 RID: 12097
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node4 : Condition
	{
		// Token: 0x06014752 RID: 83794 RVA: 0x00627D00 File Offset: 0x00626100
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node4()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014753 RID: 83795 RVA: 0x00627D34 File Offset: 0x00626134
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0C1 RID: 57537
		private int opl_p0;

		// Token: 0x0400E0C2 RID: 57538
		private int opl_p1;

		// Token: 0x0400E0C3 RID: 57539
		private int opl_p2;

		// Token: 0x0400E0C4 RID: 57540
		private int opl_p3;
	}
}
