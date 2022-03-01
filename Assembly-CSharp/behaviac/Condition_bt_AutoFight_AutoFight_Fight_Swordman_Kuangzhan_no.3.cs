using System;

namespace behaviac
{
	// Token: 0x020023DF RID: 9183
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node5 : Condition
	{
		// Token: 0x06013121 RID: 78113 RVA: 0x005A760E File Offset: 0x005A5A0E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013122 RID: 78114 RVA: 0x005A7644 File Offset: 0x005A5A44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB4D RID: 52045
		private int opl_p0;

		// Token: 0x0400CB4E RID: 52046
		private int opl_p1;

		// Token: 0x0400CB4F RID: 52047
		private int opl_p2;

		// Token: 0x0400CB50 RID: 52048
		private int opl_p3;
	}
}
