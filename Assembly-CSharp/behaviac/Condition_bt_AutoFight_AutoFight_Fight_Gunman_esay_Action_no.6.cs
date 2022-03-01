using System;

namespace behaviac
{
	// Token: 0x020020C3 RID: 8387
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node13 : Condition
	{
		// Token: 0x06012B1C RID: 76572 RVA: 0x0057D533 File Offset: 0x0057B933
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B1D RID: 76573 RVA: 0x0057D568 File Offset: 0x0057B968
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C50E RID: 50446
		private int opl_p0;

		// Token: 0x0400C50F RID: 50447
		private int opl_p1;

		// Token: 0x0400C510 RID: 50448
		private int opl_p2;

		// Token: 0x0400C511 RID: 50449
		private int opl_p3;
	}
}
