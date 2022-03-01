using System;

namespace behaviac
{
	// Token: 0x020023FE RID: 9214
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node49 : Condition
	{
		// Token: 0x0601315B RID: 78171 RVA: 0x005A834B File Offset: 0x005A674B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node49()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601315C RID: 78172 RVA: 0x005A8380 File Offset: 0x005A6780
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB84 RID: 52100
		private int opl_p0;

		// Token: 0x0400CB85 RID: 52101
		private int opl_p1;

		// Token: 0x0400CB86 RID: 52102
		private int opl_p2;

		// Token: 0x0400CB87 RID: 52103
		private int opl_p3;
	}
}
