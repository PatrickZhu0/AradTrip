using System;

namespace behaviac
{
	// Token: 0x020029B1 RID: 10673
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node103 : Condition
	{
		// Token: 0x06013C96 RID: 81046 RVA: 0x005EADEF File Offset: 0x005E91EF
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node103()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x06013C97 RID: 81047 RVA: 0x005EAE24 File Offset: 0x005E9224
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D701 RID: 55041
		private int opl_p0;

		// Token: 0x0400D702 RID: 55042
		private int opl_p1;

		// Token: 0x0400D703 RID: 55043
		private int opl_p2;

		// Token: 0x0400D704 RID: 55044
		private int opl_p3;
	}
}
