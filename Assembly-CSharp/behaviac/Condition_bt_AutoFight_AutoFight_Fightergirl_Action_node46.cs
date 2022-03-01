using System;

namespace behaviac
{
	// Token: 0x02001ED8 RID: 7896
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node46 : Condition
	{
		// Token: 0x06012755 RID: 75605 RVA: 0x0056646E File Offset: 0x0056486E
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node46()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 100;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012756 RID: 75606 RVA: 0x005664A0 File Offset: 0x005648A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C146 RID: 49478
		private int opl_p0;

		// Token: 0x0400C147 RID: 49479
		private int opl_p1;

		// Token: 0x0400C148 RID: 49480
		private int opl_p2;

		// Token: 0x0400C149 RID: 49481
		private int opl_p3;
	}
}
