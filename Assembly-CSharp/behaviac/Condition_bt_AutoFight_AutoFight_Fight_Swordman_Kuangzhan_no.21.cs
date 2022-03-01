using System;

namespace behaviac
{
	// Token: 0x020023FA RID: 9210
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node43 : Condition
	{
		// Token: 0x06013153 RID: 78163 RVA: 0x005A813B File Offset: 0x005A653B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node43()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013154 RID: 78164 RVA: 0x005A8170 File Offset: 0x005A6570
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB7C RID: 52092
		private int opl_p0;

		// Token: 0x0400CB7D RID: 52093
		private int opl_p1;

		// Token: 0x0400CB7E RID: 52094
		private int opl_p2;

		// Token: 0x0400CB7F RID: 52095
		private int opl_p3;
	}
}
