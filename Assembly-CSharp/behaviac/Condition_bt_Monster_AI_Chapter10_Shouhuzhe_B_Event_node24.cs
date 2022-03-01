using System;

namespace behaviac
{
	// Token: 0x02003143 RID: 12611
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node24 : Condition
	{
		// Token: 0x06014B29 RID: 84777 RVA: 0x0063B806 File Offset: 0x00639C06
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node24()
		{
			this.opl_p0 = 41590021;
			this.opl_p1 = 1;
		}

		// Token: 0x06014B2A RID: 84778 RVA: 0x0063B820 File Offset: 0x00639C20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4A2 RID: 58530
		private int opl_p0;

		// Token: 0x0400E4A3 RID: 58531
		private int opl_p1;
	}
}
