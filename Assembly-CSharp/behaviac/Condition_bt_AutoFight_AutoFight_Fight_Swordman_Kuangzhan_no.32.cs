using System;

namespace behaviac
{
	// Token: 0x02002408 RID: 9224
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node61 : Condition
	{
		// Token: 0x0601316F RID: 78191 RVA: 0x005A8773 File Offset: 0x005A6B73
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node61()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013170 RID: 78192 RVA: 0x005A87A8 File Offset: 0x005A6BA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB9A RID: 52122
		private int opl_p0;

		// Token: 0x0400CB9B RID: 52123
		private int opl_p1;

		// Token: 0x0400CB9C RID: 52124
		private int opl_p2;

		// Token: 0x0400CB9D RID: 52125
		private int opl_p3;
	}
}
