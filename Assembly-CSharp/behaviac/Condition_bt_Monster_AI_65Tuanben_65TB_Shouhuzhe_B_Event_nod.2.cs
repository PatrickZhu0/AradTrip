using System;

namespace behaviac
{
	// Token: 0x02002C68 RID: 11368
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node3 : Condition
	{
		// Token: 0x060141C9 RID: 82377 RVA: 0x0060A4F2 File Offset: 0x006088F2
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node3()
		{
			this.opl_p0 = 42700031;
			this.opl_p1 = 1;
		}

		// Token: 0x060141CA RID: 82378 RVA: 0x0060A50C File Offset: 0x0060890C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB83 RID: 56195
		private int opl_p0;

		// Token: 0x0400DB84 RID: 56196
		private int opl_p1;
	}
}
