using System;

namespace behaviac
{
	// Token: 0x020020CF RID: 8399
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node28 : Condition
	{
		// Token: 0x06012B34 RID: 76596 RVA: 0x0057DB67 File Offset: 0x0057BF67
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node28()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B35 RID: 76597 RVA: 0x0057DB9C File Offset: 0x0057BF9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C526 RID: 50470
		private int opl_p0;

		// Token: 0x0400C527 RID: 50471
		private int opl_p1;

		// Token: 0x0400C528 RID: 50472
		private int opl_p2;

		// Token: 0x0400C529 RID: 50473
		private int opl_p3;
	}
}
