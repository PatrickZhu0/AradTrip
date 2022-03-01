using System;

namespace behaviac
{
	// Token: 0x02002498 RID: 9368
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node13 : Condition
	{
		// Token: 0x0601327C RID: 78460 RVA: 0x005AF5FB File Offset: 0x005AD9FB
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node13()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x0601327D RID: 78461 RVA: 0x005AF630 File Offset: 0x005ADA30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC93 RID: 52371
		private int opl_p0;

		// Token: 0x0400CC94 RID: 52372
		private int opl_p1;

		// Token: 0x0400CC95 RID: 52373
		private int opl_p2;

		// Token: 0x0400CC96 RID: 52374
		private int opl_p3;
	}
}
