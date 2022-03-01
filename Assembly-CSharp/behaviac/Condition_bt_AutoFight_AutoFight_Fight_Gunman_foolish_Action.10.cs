using System;

namespace behaviac
{
	// Token: 0x020020E3 RID: 8419
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node23 : Condition
	{
		// Token: 0x06012B5B RID: 76635 RVA: 0x0057EC8B File Offset: 0x0057D08B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node23()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012B5C RID: 76636 RVA: 0x0057ECC0 File Offset: 0x0057D0C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C54D RID: 50509
		private int opl_p0;

		// Token: 0x0400C54E RID: 50510
		private int opl_p1;

		// Token: 0x0400C54F RID: 50511
		private int opl_p2;

		// Token: 0x0400C550 RID: 50512
		private int opl_p3;
	}
}
