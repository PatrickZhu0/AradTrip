using System;

namespace behaviac
{
	// Token: 0x020028BB RID: 10427
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node43 : Condition
	{
		// Token: 0x06013AB0 RID: 80560 RVA: 0x005DF66B File Offset: 0x005DDA6B
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node43()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013AB1 RID: 80561 RVA: 0x005DF6A0 File Offset: 0x005DDAA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D50C RID: 54540
		private int opl_p0;

		// Token: 0x0400D50D RID: 54541
		private int opl_p1;

		// Token: 0x0400D50E RID: 54542
		private int opl_p2;

		// Token: 0x0400D50F RID: 54543
		private int opl_p3;
	}
}
