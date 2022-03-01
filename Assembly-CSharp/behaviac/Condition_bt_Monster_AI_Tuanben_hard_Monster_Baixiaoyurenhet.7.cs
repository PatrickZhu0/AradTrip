using System;

namespace behaviac
{
	// Token: 0x02003D0C RID: 15628
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node1 : Condition
	{
		// Token: 0x060161B5 RID: 90549 RVA: 0x006AEF82 File Offset: 0x006AD382
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node1()
		{
			this.opl_p0 = 81290011;
			this.opl_p1 = 2;
		}

		// Token: 0x060161B6 RID: 90550 RVA: 0x006AEF9C File Offset: 0x006AD39C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA46 RID: 64070
		private int opl_p0;

		// Token: 0x0400FA47 RID: 64071
		private int opl_p1;
	}
}
