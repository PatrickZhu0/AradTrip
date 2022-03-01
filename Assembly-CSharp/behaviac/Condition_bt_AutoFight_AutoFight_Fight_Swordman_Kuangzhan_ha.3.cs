using System;

namespace behaviac
{
	// Token: 0x02002367 RID: 9063
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node5 : Condition
	{
		// Token: 0x06013039 RID: 77881 RVA: 0x005A031E File Offset: 0x0059E71E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601303A RID: 77882 RVA: 0x005A0354 File Offset: 0x0059E754
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA50 RID: 51792
		private int opl_p0;

		// Token: 0x0400CA51 RID: 51793
		private int opl_p1;

		// Token: 0x0400CA52 RID: 51794
		private int opl_p2;

		// Token: 0x0400CA53 RID: 51795
		private int opl_p3;
	}
}
