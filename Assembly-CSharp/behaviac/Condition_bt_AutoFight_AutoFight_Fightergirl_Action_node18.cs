using System;

namespace behaviac
{
	// Token: 0x02001EE5 RID: 7909
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node18 : Condition
	{
		// Token: 0x0601276F RID: 75631 RVA: 0x005669F2 File Offset: 0x00564DF2
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node18()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012770 RID: 75632 RVA: 0x00566A28 File Offset: 0x00564E28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C162 RID: 49506
		private int opl_p0;

		// Token: 0x0400C163 RID: 49507
		private int opl_p1;

		// Token: 0x0400C164 RID: 49508
		private int opl_p2;

		// Token: 0x0400C165 RID: 49509
		private int opl_p3;
	}
}
