using System;

namespace behaviac
{
	// Token: 0x020020C7 RID: 8391
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node18 : Condition
	{
		// Token: 0x06012B24 RID: 76580 RVA: 0x0057D77F File Offset: 0x0057BB7F
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node18()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B25 RID: 76581 RVA: 0x0057D7B4 File Offset: 0x0057BBB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C516 RID: 50454
		private int opl_p0;

		// Token: 0x0400C517 RID: 50455
		private int opl_p1;

		// Token: 0x0400C518 RID: 50456
		private int opl_p2;

		// Token: 0x0400C519 RID: 50457
		private int opl_p3;
	}
}
