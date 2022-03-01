using System;

namespace behaviac
{
	// Token: 0x02002FA1 RID: 12193
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node54 : Condition
	{
		// Token: 0x06014810 RID: 83984 RVA: 0x0062B166 File Offset: 0x00629566
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node54()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06014811 RID: 83985 RVA: 0x0062B19C File Offset: 0x0062959C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E171 RID: 57713
		private int opl_p0;

		// Token: 0x0400E172 RID: 57714
		private int opl_p1;

		// Token: 0x0400E173 RID: 57715
		private int opl_p2;

		// Token: 0x0400E174 RID: 57716
		private int opl_p3;
	}
}
