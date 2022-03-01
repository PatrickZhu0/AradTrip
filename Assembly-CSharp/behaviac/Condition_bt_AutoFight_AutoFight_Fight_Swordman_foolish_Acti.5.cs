using System;

namespace behaviac
{
	// Token: 0x02002283 RID: 8835
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node5 : Condition
	{
		// Token: 0x06012E88 RID: 77448 RVA: 0x00593DF2 File Offset: 0x005921F2
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node5()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012E89 RID: 77449 RVA: 0x00593E28 File Offset: 0x00592228
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C894 RID: 51348
		private int opl_p0;

		// Token: 0x0400C895 RID: 51349
		private int opl_p1;

		// Token: 0x0400C896 RID: 51350
		private int opl_p2;

		// Token: 0x0400C897 RID: 51351
		private int opl_p3;
	}
}
