using System;

namespace behaviac
{
	// Token: 0x020020D7 RID: 8407
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node8 : Condition
	{
		// Token: 0x06012B43 RID: 76611 RVA: 0x0057E657 File Offset: 0x0057CA57
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012B44 RID: 76612 RVA: 0x0057E68C File Offset: 0x0057CA8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C535 RID: 50485
		private int opl_p0;

		// Token: 0x0400C536 RID: 50486
		private int opl_p1;

		// Token: 0x0400C537 RID: 50487
		private int opl_p2;

		// Token: 0x0400C538 RID: 50488
		private int opl_p3;
	}
}
