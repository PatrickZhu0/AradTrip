using System;

namespace behaviac
{
	// Token: 0x020020DF RID: 8415
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node18 : Condition
	{
		// Token: 0x06012B53 RID: 76627 RVA: 0x0057EA3F File Offset: 0x0057CE3F
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node18()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B54 RID: 76628 RVA: 0x0057EA74 File Offset: 0x0057CE74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C545 RID: 50501
		private int opl_p0;

		// Token: 0x0400C546 RID: 50502
		private int opl_p1;

		// Token: 0x0400C547 RID: 50503
		private int opl_p2;

		// Token: 0x0400C548 RID: 50504
		private int opl_p3;
	}
}
