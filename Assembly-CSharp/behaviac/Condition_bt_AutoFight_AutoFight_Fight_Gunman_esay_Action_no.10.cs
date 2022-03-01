using System;

namespace behaviac
{
	// Token: 0x020020CB RID: 8395
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node23 : Condition
	{
		// Token: 0x06012B2C RID: 76588 RVA: 0x0057D9CB File Offset: 0x0057BDCB
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node23()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012B2D RID: 76589 RVA: 0x0057DA00 File Offset: 0x0057BE00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C51E RID: 50462
		private int opl_p0;

		// Token: 0x0400C51F RID: 50463
		private int opl_p1;

		// Token: 0x0400C520 RID: 50464
		private int opl_p2;

		// Token: 0x0400C521 RID: 50465
		private int opl_p3;
	}
}
