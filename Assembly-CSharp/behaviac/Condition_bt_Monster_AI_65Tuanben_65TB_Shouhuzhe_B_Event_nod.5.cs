using System;

namespace behaviac
{
	// Token: 0x02002C6E RID: 11374
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node23 : Condition
	{
		// Token: 0x060141D5 RID: 82389 RVA: 0x0060A70A File Offset: 0x00608B0A
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node23()
		{
			this.opl_p0 = 42700031;
			this.opl_p1 = 1;
		}

		// Token: 0x060141D6 RID: 82390 RVA: 0x0060A724 File Offset: 0x00608B24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB97 RID: 56215
		private int opl_p0;

		// Token: 0x0400DB98 RID: 56216
		private int opl_p1;
	}
}
