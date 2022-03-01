using System;

namespace behaviac
{
	// Token: 0x02002490 RID: 9360
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node21 : Condition
	{
		// Token: 0x0601326C RID: 78444 RVA: 0x005AF2F7 File Offset: 0x005AD6F7
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node21()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x0601326D RID: 78445 RVA: 0x005AF32C File Offset: 0x005AD72C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC85 RID: 52357
		private int opl_p0;

		// Token: 0x0400CC86 RID: 52358
		private int opl_p1;

		// Token: 0x0400CC87 RID: 52359
		private int opl_p2;

		// Token: 0x0400CC88 RID: 52360
		private int opl_p3;
	}
}
