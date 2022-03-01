using System;

namespace behaviac
{
	// Token: 0x02003AFF RID: 15103
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node1 : Condition
	{
		// Token: 0x06015DB9 RID: 89529 RVA: 0x0069AE6E File Offset: 0x0069926E
		public Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node1()
		{
			this.opl_p0 = 80030011;
			this.opl_p1 = 2;
		}

		// Token: 0x06015DBA RID: 89530 RVA: 0x0069AE88 File Offset: 0x00699288
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6B3 RID: 63155
		private int opl_p0;

		// Token: 0x0400F6B4 RID: 63156
		private int opl_p1;
	}
}
