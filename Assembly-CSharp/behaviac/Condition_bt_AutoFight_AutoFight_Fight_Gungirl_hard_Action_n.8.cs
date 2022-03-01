using System;

namespace behaviac
{
	// Token: 0x02001FB4 RID: 8116
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node18 : Condition
	{
		// Token: 0x06012906 RID: 76038 RVA: 0x005705A7 File Offset: 0x0056E9A7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node18()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012907 RID: 76039 RVA: 0x005705DC File Offset: 0x0056E9DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2F7 RID: 49911
		private int opl_p0;

		// Token: 0x0400C2F8 RID: 49912
		private int opl_p1;

		// Token: 0x0400C2F9 RID: 49913
		private int opl_p2;

		// Token: 0x0400C2FA RID: 49914
		private int opl_p3;
	}
}
