using System;

namespace behaviac
{
	// Token: 0x02003D30 RID: 15664
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node1 : Condition
	{
		// Token: 0x060161F9 RID: 90617 RVA: 0x006B039A File Offset: 0x006AE79A
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node1()
		{
			this.opl_p0 = 81280011;
			this.opl_p1 = 2;
		}

		// Token: 0x060161FA RID: 90618 RVA: 0x006B03B4 File Offset: 0x006AE7B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA70 RID: 64112
		private int opl_p0;

		// Token: 0x0400FA71 RID: 64113
		private int opl_p1;
	}
}
