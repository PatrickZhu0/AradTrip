using System;

namespace behaviac
{
	// Token: 0x02003128 RID: 12584
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node23 : Condition
	{
		// Token: 0x06014AF5 RID: 84725 RVA: 0x0063A8D2 File Offset: 0x00638CD2
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node23()
		{
			this.opl_p0 = 41580021;
			this.opl_p1 = 1;
		}

		// Token: 0x06014AF6 RID: 84726 RVA: 0x0063A8EC File Offset: 0x00638CEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E468 RID: 58472
		private int opl_p0;

		// Token: 0x0400E469 RID: 58473
		private int opl_p1;
	}
}
