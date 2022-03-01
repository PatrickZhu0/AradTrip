using System;

namespace behaviac
{
	// Token: 0x0200249C RID: 9372
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node5 : Condition
	{
		// Token: 0x06013284 RID: 78468 RVA: 0x005AF72B File Offset: 0x005ADB2B
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node5()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06013285 RID: 78469 RVA: 0x005AF760 File Offset: 0x005ADB60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC9A RID: 52378
		private int opl_p0;

		// Token: 0x0400CC9B RID: 52379
		private int opl_p1;

		// Token: 0x0400CC9C RID: 52380
		private int opl_p2;

		// Token: 0x0400CC9D RID: 52381
		private int opl_p3;
	}
}
