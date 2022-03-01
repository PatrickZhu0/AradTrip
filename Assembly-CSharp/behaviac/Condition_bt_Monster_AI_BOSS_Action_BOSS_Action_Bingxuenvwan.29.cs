using System;

namespace behaviac
{
	// Token: 0x02002F92 RID: 12178
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node39 : Condition
	{
		// Token: 0x060147F2 RID: 83954 RVA: 0x0062AB72 File Offset: 0x00628F72
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node39()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060147F3 RID: 83955 RVA: 0x0062ABA8 File Offset: 0x00628FA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E156 RID: 57686
		private int opl_p0;

		// Token: 0x0400E157 RID: 57687
		private int opl_p1;

		// Token: 0x0400E158 RID: 57688
		private int opl_p2;

		// Token: 0x0400E159 RID: 57689
		private int opl_p3;
	}
}
