using System;

namespace behaviac
{
	// Token: 0x02001F0B RID: 7947
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node22 : Condition
	{
		// Token: 0x060127BA RID: 75706 RVA: 0x005684AE File Offset: 0x005668AE
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060127BB RID: 75707 RVA: 0x005684E4 File Offset: 0x005668E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1AF RID: 49583
		private int opl_p0;

		// Token: 0x0400C1B0 RID: 49584
		private int opl_p1;

		// Token: 0x0400C1B1 RID: 49585
		private int opl_p2;

		// Token: 0x0400C1B2 RID: 49586
		private int opl_p3;
	}
}
