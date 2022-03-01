using System;

namespace behaviac
{
	// Token: 0x02002494 RID: 9364
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node8 : Condition
	{
		// Token: 0x06013274 RID: 78452 RVA: 0x005AF47B File Offset: 0x005AD87B
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node8()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06013275 RID: 78453 RVA: 0x005AF4B0 File Offset: 0x005AD8B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC8C RID: 52364
		private int opl_p0;

		// Token: 0x0400CC8D RID: 52365
		private int opl_p1;

		// Token: 0x0400CC8E RID: 52366
		private int opl_p2;

		// Token: 0x0400CC8F RID: 52367
		private int opl_p3;
	}
}
