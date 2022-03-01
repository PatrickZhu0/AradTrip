using System;

namespace behaviac
{
	// Token: 0x020020B3 RID: 8371
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node23 : Condition
	{
		// Token: 0x06012AFD RID: 76541 RVA: 0x0057C70B File Offset: 0x0057AB0B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node23()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012AFE RID: 76542 RVA: 0x0057C740 File Offset: 0x0057AB40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4EF RID: 50415
		private int opl_p0;

		// Token: 0x0400C4F0 RID: 50416
		private int opl_p1;

		// Token: 0x0400C4F1 RID: 50417
		private int opl_p2;

		// Token: 0x0400C4F2 RID: 50418
		private int opl_p3;
	}
}
