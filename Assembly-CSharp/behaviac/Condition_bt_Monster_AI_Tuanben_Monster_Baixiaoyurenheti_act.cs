using System;

namespace behaviac
{
	// Token: 0x02003AE2 RID: 15074
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node0 : Condition
	{
		// Token: 0x06015D82 RID: 89474 RVA: 0x00699DD8 File Offset: 0x006981D8
		public Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node0()
		{
			this.opl_p0 = 80020011;
			this.opl_p1 = 2;
		}

		// Token: 0x06015D83 RID: 89475 RVA: 0x00699DF4 File Offset: 0x006981F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F691 RID: 63121
		private int opl_p0;

		// Token: 0x0400F692 RID: 63122
		private int opl_p1;
	}
}
