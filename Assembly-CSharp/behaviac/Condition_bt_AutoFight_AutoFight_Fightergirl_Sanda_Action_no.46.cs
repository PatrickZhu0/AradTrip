using System;

namespace behaviac
{
	// Token: 0x02001F5F RID: 8031
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node70 : Condition
	{
		// Token: 0x06012861 RID: 75873 RVA: 0x0056B8AF File Offset: 0x00569CAF
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node70()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012862 RID: 75874 RVA: 0x0056B8E4 File Offset: 0x00569CE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C25B RID: 49755
		private int opl_p0;

		// Token: 0x0400C25C RID: 49756
		private int opl_p1;

		// Token: 0x0400C25D RID: 49757
		private int opl_p2;

		// Token: 0x0400C25E RID: 49758
		private int opl_p3;
	}
}
