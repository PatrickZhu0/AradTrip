using System;

namespace behaviac
{
	// Token: 0x02003D13 RID: 15635
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node0 : Condition
	{
		// Token: 0x060161C2 RID: 90562 RVA: 0x006AF304 File Offset: 0x006AD704
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node0()
		{
			this.opl_p0 = 81300011;
			this.opl_p1 = 2;
		}

		// Token: 0x060161C3 RID: 90563 RVA: 0x006AF320 File Offset: 0x006AD720
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA4E RID: 64078
		private int opl_p0;

		// Token: 0x0400FA4F RID: 64079
		private int opl_p1;
	}
}
