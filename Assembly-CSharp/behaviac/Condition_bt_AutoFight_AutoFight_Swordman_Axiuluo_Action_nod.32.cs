using System;

namespace behaviac
{
	// Token: 0x020028C1 RID: 10433
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node52 : Condition
	{
		// Token: 0x06013ABC RID: 80572 RVA: 0x005DF8F9 File Offset: 0x005DDCF9
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013ABD RID: 80573 RVA: 0x005DF918 File Offset: 0x005DDD18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D51B RID: 54555
		private BE_Target opl_p0;

		// Token: 0x0400D51C RID: 54556
		private BE_Equal opl_p1;

		// Token: 0x0400D51D RID: 54557
		private BE_State opl_p2;
	}
}
