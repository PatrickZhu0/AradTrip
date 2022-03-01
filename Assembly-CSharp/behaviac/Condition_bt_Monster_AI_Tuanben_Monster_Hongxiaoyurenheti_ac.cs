using System;

namespace behaviac
{
	// Token: 0x02003AF4 RID: 15092
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node0 : Condition
	{
		// Token: 0x06015DA4 RID: 89508 RVA: 0x0069A7E4 File Offset: 0x00698BE4
		public Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node0()
		{
			this.opl_p0 = 80030011;
			this.opl_p1 = 2;
		}

		// Token: 0x06015DA5 RID: 89509 RVA: 0x0069A800 File Offset: 0x00698C00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6A6 RID: 63142
		private int opl_p0;

		// Token: 0x0400F6A7 RID: 63143
		private int opl_p1;
	}
}
