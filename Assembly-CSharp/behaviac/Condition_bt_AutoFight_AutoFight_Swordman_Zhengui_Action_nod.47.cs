using System;

namespace behaviac
{
	// Token: 0x020029BA RID: 10682
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node38 : Condition
	{
		// Token: 0x06013CA8 RID: 81064 RVA: 0x005EB1B7 File Offset: 0x005E95B7
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node38()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x06013CA9 RID: 81065 RVA: 0x005EB1EC File Offset: 0x005E95EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D714 RID: 55060
		private int opl_p0;

		// Token: 0x0400D715 RID: 55061
		private int opl_p1;

		// Token: 0x0400D716 RID: 55062
		private int opl_p2;

		// Token: 0x0400D717 RID: 55063
		private int opl_p3;
	}
}
