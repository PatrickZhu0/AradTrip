using System;

namespace behaviac
{
	// Token: 0x02003B06 RID: 15110
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node0 : Condition
	{
		// Token: 0x06015DC6 RID: 89542 RVA: 0x0069B1F0 File Offset: 0x006995F0
		public Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node0()
		{
			this.opl_p0 = 80010011;
			this.opl_p1 = 2;
		}

		// Token: 0x06015DC7 RID: 89543 RVA: 0x0069B20C File Offset: 0x0069960C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6BB RID: 63163
		private int opl_p0;

		// Token: 0x0400F6BC RID: 63164
		private int opl_p1;
	}
}
