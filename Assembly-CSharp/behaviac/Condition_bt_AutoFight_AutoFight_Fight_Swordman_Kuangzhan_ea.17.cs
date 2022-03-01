using System;

namespace behaviac
{
	// Token: 0x0200231D RID: 8989
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node38 : Condition
	{
		// Token: 0x06012FAD RID: 77741 RVA: 0x0059C69F File Offset: 0x0059AA9F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node38()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012FAE RID: 77742 RVA: 0x0059C6D4 File Offset: 0x0059AAD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9C2 RID: 51650
		private int opl_p0;

		// Token: 0x0400C9C3 RID: 51651
		private int opl_p1;

		// Token: 0x0400C9C4 RID: 51652
		private int opl_p2;

		// Token: 0x0400C9C5 RID: 51653
		private int opl_p3;
	}
}
