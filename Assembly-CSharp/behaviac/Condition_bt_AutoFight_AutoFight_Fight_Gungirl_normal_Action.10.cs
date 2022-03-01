using System;

namespace behaviac
{
	// Token: 0x0200209B RID: 8347
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node23 : Condition
	{
		// Token: 0x06012ACE RID: 76494 RVA: 0x0057B44B File Offset: 0x0057984B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node23()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012ACF RID: 76495 RVA: 0x0057B480 File Offset: 0x00579880
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4C0 RID: 50368
		private int opl_p0;

		// Token: 0x0400C4C1 RID: 50369
		private int opl_p1;

		// Token: 0x0400C4C2 RID: 50370
		private int opl_p2;

		// Token: 0x0400C4C3 RID: 50371
		private int opl_p3;
	}
}
