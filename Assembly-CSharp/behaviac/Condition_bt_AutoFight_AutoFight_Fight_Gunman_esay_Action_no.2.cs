using System;

namespace behaviac
{
	// Token: 0x020020BB RID: 8379
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node3 : Condition
	{
		// Token: 0x06012B0C RID: 76556 RVA: 0x0057D14B File Offset: 0x0057B54B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node3()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B0D RID: 76557 RVA: 0x0057D180 File Offset: 0x0057B580
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4FE RID: 50430
		private int opl_p0;

		// Token: 0x0400C4FF RID: 50431
		private int opl_p1;

		// Token: 0x0400C500 RID: 50432
		private int opl_p2;

		// Token: 0x0400C501 RID: 50433
		private int opl_p3;
	}
}
