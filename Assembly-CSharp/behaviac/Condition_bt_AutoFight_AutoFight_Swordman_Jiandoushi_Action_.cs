using System;

namespace behaviac
{
	// Token: 0x020028E2 RID: 10466
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node6 : Condition
	{
		// Token: 0x06013AFC RID: 80636 RVA: 0x005E1F18 File Offset: 0x005E0318
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 230000;
		}

		// Token: 0x06013AFD RID: 80637 RVA: 0x005E1F3C File Offset: 0x005E033C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D55F RID: 54623
		private BE_Target opl_p0;

		// Token: 0x0400D560 RID: 54624
		private BE_Equal opl_p1;

		// Token: 0x0400D561 RID: 54625
		private int opl_p2;
	}
}
