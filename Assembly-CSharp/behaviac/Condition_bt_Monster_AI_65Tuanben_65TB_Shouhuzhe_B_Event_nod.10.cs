using System;

namespace behaviac
{
	// Token: 0x02002C74 RID: 11380
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node24 : Condition
	{
		// Token: 0x060141E1 RID: 82401 RVA: 0x0060A95A File Offset: 0x00608D5A
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node24()
		{
			this.opl_p0 = 42700031;
			this.opl_p1 = 1;
		}

		// Token: 0x060141E2 RID: 82402 RVA: 0x0060A974 File Offset: 0x00608D74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBA3 RID: 56227
		private int opl_p0;

		// Token: 0x0400DBA4 RID: 56228
		private int opl_p1;
	}
}
