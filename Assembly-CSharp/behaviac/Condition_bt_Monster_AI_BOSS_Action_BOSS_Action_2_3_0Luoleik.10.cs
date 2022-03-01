using System;

namespace behaviac
{
	// Token: 0x02002F5E RID: 12126
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node19 : Condition
	{
		// Token: 0x0601478B RID: 83851 RVA: 0x00628E36 File Offset: 0x00627236
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node19()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 2000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601478C RID: 83852 RVA: 0x00628E6C File Offset: 0x0062726C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0F9 RID: 57593
		private int opl_p0;

		// Token: 0x0400E0FA RID: 57594
		private int opl_p1;

		// Token: 0x0400E0FB RID: 57595
		private int opl_p2;

		// Token: 0x0400E0FC RID: 57596
		private int opl_p3;
	}
}
