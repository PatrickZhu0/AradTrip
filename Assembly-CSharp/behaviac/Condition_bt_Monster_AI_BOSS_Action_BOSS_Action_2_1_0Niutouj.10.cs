using System;

namespace behaviac
{
	// Token: 0x02002F4D RID: 12109
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node19 : Condition
	{
		// Token: 0x0601476A RID: 83818 RVA: 0x0062821A File Offset: 0x0062661A
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node19()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601476B RID: 83819 RVA: 0x00628250 File Offset: 0x00626650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0D9 RID: 57561
		private int opl_p0;

		// Token: 0x0400E0DA RID: 57562
		private int opl_p1;

		// Token: 0x0400E0DB RID: 57563
		private int opl_p2;

		// Token: 0x0400E0DC RID: 57564
		private int opl_p3;
	}
}
