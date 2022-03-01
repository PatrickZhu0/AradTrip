using System;

namespace behaviac
{
	// Token: 0x020020AB RID: 8363
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node13 : Condition
	{
		// Token: 0x06012AED RID: 76525 RVA: 0x0057C273 File Offset: 0x0057A673
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012AEE RID: 76526 RVA: 0x0057C2A8 File Offset: 0x0057A6A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4DF RID: 50399
		private int opl_p0;

		// Token: 0x0400C4E0 RID: 50400
		private int opl_p1;

		// Token: 0x0400C4E1 RID: 50401
		private int opl_p2;

		// Token: 0x0400C4E2 RID: 50402
		private int opl_p3;
	}
}
