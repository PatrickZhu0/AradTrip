using System;

namespace behaviac
{
	// Token: 0x0200312E RID: 12590
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node24 : Condition
	{
		// Token: 0x06014B01 RID: 84737 RVA: 0x0063AB22 File Offset: 0x00638F22
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node24()
		{
			this.opl_p0 = 41580021;
			this.opl_p1 = 1;
		}

		// Token: 0x06014B02 RID: 84738 RVA: 0x0063AB3C File Offset: 0x00638F3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E474 RID: 58484
		private int opl_p0;

		// Token: 0x0400E475 RID: 58485
		private int opl_p1;
	}
}
