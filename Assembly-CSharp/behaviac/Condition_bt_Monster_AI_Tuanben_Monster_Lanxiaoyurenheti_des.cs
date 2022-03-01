using System;

namespace behaviac
{
	// Token: 0x02003B11 RID: 15121
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node1 : Condition
	{
		// Token: 0x06015DDB RID: 89563 RVA: 0x0069B87A File Offset: 0x00699C7A
		public Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node1()
		{
			this.opl_p0 = 80010011;
			this.opl_p1 = 2;
		}

		// Token: 0x06015DDC RID: 89564 RVA: 0x0069B894 File Offset: 0x00699C94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6C8 RID: 63176
		private int opl_p0;

		// Token: 0x0400F6C9 RID: 63177
		private int opl_p1;
	}
}
