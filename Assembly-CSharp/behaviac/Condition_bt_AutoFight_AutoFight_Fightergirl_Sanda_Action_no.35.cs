using System;

namespace behaviac
{
	// Token: 0x02001F51 RID: 8017
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node23 : Condition
	{
		// Token: 0x06012845 RID: 75845 RVA: 0x0056B2CF File Offset: 0x005696CF
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node23()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012846 RID: 75846 RVA: 0x0056B304 File Offset: 0x00569704
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C23D RID: 49725
		private int opl_p0;

		// Token: 0x0400C23E RID: 49726
		private int opl_p1;

		// Token: 0x0400C23F RID: 49727
		private int opl_p2;

		// Token: 0x0400C240 RID: 49728
		private int opl_p3;
	}
}
