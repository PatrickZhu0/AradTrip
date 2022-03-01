using System;

namespace behaviac
{
	// Token: 0x02003AB0 RID: 15024
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node0 : Condition
	{
		// Token: 0x06015D22 RID: 89378 RVA: 0x00697C51 File Offset: 0x00696051
		public Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node0()
		{
			this.opl_p0 = 80060011;
			this.opl_p1 = 3;
		}

		// Token: 0x06015D23 RID: 89379 RVA: 0x00697C6C File Offset: 0x0069606C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F641 RID: 63041
		private int opl_p0;

		// Token: 0x0400F642 RID: 63042
		private int opl_p1;
	}
}
