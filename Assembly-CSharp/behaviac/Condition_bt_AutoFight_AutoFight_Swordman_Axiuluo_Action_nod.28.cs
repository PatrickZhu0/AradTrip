using System;

namespace behaviac
{
	// Token: 0x020028BC RID: 10428
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node9 : Condition
	{
		// Token: 0x06013AB2 RID: 80562 RVA: 0x005DF6E5 File Offset: 0x005DDAE5
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node9()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013AB3 RID: 80563 RVA: 0x005DF704 File Offset: 0x005DDB04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D510 RID: 54544
		private BE_Target opl_p0;

		// Token: 0x0400D511 RID: 54545
		private BE_Equal opl_p1;

		// Token: 0x0400D512 RID: 54546
		private BE_State opl_p2;
	}
}
