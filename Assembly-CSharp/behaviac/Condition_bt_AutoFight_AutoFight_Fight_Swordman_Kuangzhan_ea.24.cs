using System;

namespace behaviac
{
	// Token: 0x02002326 RID: 8998
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node49 : Condition
	{
		// Token: 0x06012FBF RID: 77759 RVA: 0x0059CAC3 File Offset: 0x0059AEC3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node49()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012FC0 RID: 77760 RVA: 0x0059CAF8 File Offset: 0x0059AEF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9D5 RID: 51669
		private int opl_p0;

		// Token: 0x0400C9D6 RID: 51670
		private int opl_p1;

		// Token: 0x0400C9D7 RID: 51671
		private int opl_p2;

		// Token: 0x0400C9D8 RID: 51672
		private int opl_p3;
	}
}
