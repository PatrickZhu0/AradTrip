using System;

namespace behaviac
{
	// Token: 0x02001FB0 RID: 8112
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node13 : Condition
	{
		// Token: 0x060128FE RID: 76030 RVA: 0x0057035B File Offset: 0x0056E75B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060128FF RID: 76031 RVA: 0x00570390 File Offset: 0x0056E790
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2EF RID: 49903
		private int opl_p0;

		// Token: 0x0400C2F0 RID: 49904
		private int opl_p1;

		// Token: 0x0400C2F1 RID: 49905
		private int opl_p2;

		// Token: 0x0400C2F2 RID: 49906
		private int opl_p3;
	}
}
