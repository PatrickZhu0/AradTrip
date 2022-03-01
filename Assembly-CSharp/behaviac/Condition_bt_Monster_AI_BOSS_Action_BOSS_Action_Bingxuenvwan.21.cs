using System;

namespace behaviac
{
	// Token: 0x02002F88 RID: 12168
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node29 : Condition
	{
		// Token: 0x060147DE RID: 83934 RVA: 0x0062A77A File Offset: 0x00628B7A
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node29()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060147DF RID: 83935 RVA: 0x0062A7B0 File Offset: 0x00628BB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E144 RID: 57668
		private int opl_p0;

		// Token: 0x0400E145 RID: 57669
		private int opl_p1;

		// Token: 0x0400E146 RID: 57670
		private int opl_p2;

		// Token: 0x0400E147 RID: 57671
		private int opl_p3;
	}
}
