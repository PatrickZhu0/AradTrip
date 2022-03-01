using System;

namespace behaviac
{
	// Token: 0x02002F83 RID: 12163
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node24 : Condition
	{
		// Token: 0x060147D4 RID: 83924 RVA: 0x0062A57E File Offset: 0x0062897E
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node24()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060147D5 RID: 83925 RVA: 0x0062A5B4 File Offset: 0x006289B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E13B RID: 57659
		private int opl_p0;

		// Token: 0x0400E13C RID: 57660
		private int opl_p1;

		// Token: 0x0400E13D RID: 57661
		private int opl_p2;

		// Token: 0x0400E13E RID: 57662
		private int opl_p3;
	}
}
