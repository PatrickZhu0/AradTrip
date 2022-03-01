using System;

namespace behaviac
{
	// Token: 0x02003AED RID: 15085
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node1 : Condition
	{
		// Token: 0x06015D97 RID: 89495 RVA: 0x0069A462 File Offset: 0x00698862
		public Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node1()
		{
			this.opl_p0 = 80020011;
			this.opl_p1 = 2;
		}

		// Token: 0x06015D98 RID: 89496 RVA: 0x0069A47C File Offset: 0x0069887C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F69E RID: 63134
		private int opl_p0;

		// Token: 0x0400F69F RID: 63135
		private int opl_p1;
	}
}
