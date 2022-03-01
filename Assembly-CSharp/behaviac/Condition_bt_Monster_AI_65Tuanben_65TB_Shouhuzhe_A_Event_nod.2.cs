using System;

namespace behaviac
{
	// Token: 0x02002C3F RID: 11327
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node3 : Condition
	{
		// Token: 0x0601417A RID: 82298 RVA: 0x00608B96 File Offset: 0x00606F96
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node3()
		{
			this.opl_p0 = 42690031;
			this.opl_p1 = 1;
		}

		// Token: 0x0601417B RID: 82299 RVA: 0x00608BB0 File Offset: 0x00606FB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB39 RID: 56121
		private int opl_p0;

		// Token: 0x0400DB3A RID: 56122
		private int opl_p1;
	}
}
