using System;

namespace behaviac
{
	// Token: 0x020029D0 RID: 10704
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node63 : Condition
	{
		// Token: 0x06013CD4 RID: 81108 RVA: 0x005EBBB3 File Offset: 0x005E9FB3
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node63()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013CD5 RID: 81109 RVA: 0x005EBBE8 File Offset: 0x005E9FE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D742 RID: 55106
		private int opl_p0;

		// Token: 0x0400D743 RID: 55107
		private int opl_p1;

		// Token: 0x0400D744 RID: 55108
		private int opl_p2;

		// Token: 0x0400D745 RID: 55109
		private int opl_p3;
	}
}
