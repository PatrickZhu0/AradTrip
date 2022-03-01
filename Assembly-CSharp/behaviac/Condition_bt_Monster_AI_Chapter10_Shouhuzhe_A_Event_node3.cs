using System;

namespace behaviac
{
	// Token: 0x02003122 RID: 12578
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node3 : Condition
	{
		// Token: 0x06014AE9 RID: 84713 RVA: 0x0063A6BA File Offset: 0x00638ABA
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node3()
		{
			this.opl_p0 = 41580021;
			this.opl_p1 = 1;
		}

		// Token: 0x06014AEA RID: 84714 RVA: 0x0063A6D4 File Offset: 0x00638AD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E454 RID: 58452
		private int opl_p0;

		// Token: 0x0400E455 RID: 58453
		private int opl_p1;
	}
}
