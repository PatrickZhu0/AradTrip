using System;

namespace behaviac
{
	// Token: 0x02001F49 RID: 8009
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node63 : Condition
	{
		// Token: 0x06012835 RID: 75829 RVA: 0x0056AF03 File Offset: 0x00569303
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node63()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012836 RID: 75830 RVA: 0x0056AF38 File Offset: 0x00569338
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C22D RID: 49709
		private int opl_p0;

		// Token: 0x0400C22E RID: 49710
		private int opl_p1;

		// Token: 0x0400C22F RID: 49711
		private int opl_p2;

		// Token: 0x0400C230 RID: 49712
		private int opl_p3;
	}
}
