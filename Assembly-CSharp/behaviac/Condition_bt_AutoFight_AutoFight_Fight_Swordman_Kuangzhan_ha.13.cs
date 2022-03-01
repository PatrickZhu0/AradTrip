using System;

namespace behaviac
{
	// Token: 0x02002377 RID: 9079
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node30 : Condition
	{
		// Token: 0x06013056 RID: 77910 RVA: 0x005A0A2E File Offset: 0x0059EE2E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node30()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013057 RID: 77911 RVA: 0x005A0A60 File Offset: 0x0059EE60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA6B RID: 51819
		private int opl_p0;

		// Token: 0x0400CA6C RID: 51820
		private int opl_p1;

		// Token: 0x0400CA6D RID: 51821
		private int opl_p2;

		// Token: 0x0400CA6E RID: 51822
		private int opl_p3;
	}
}
