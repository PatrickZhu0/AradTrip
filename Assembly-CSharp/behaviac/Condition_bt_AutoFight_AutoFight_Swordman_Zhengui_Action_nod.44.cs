using System;

namespace behaviac
{
	// Token: 0x020029B6 RID: 10678
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node91 : Condition
	{
		// Token: 0x06013CA0 RID: 81056 RVA: 0x005EB003 File Offset: 0x005E9403
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node91()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013CA1 RID: 81057 RVA: 0x005EB038 File Offset: 0x005E9438
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D70C RID: 55052
		private int opl_p0;

		// Token: 0x0400D70D RID: 55053
		private int opl_p1;

		// Token: 0x0400D70E RID: 55054
		private int opl_p2;

		// Token: 0x0400D70F RID: 55055
		private int opl_p3;
	}
}
