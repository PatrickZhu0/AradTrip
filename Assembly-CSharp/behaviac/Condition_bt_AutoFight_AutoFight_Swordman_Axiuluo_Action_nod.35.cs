using System;

namespace behaviac
{
	// Token: 0x020028C5 RID: 10437
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node55 : Condition
	{
		// Token: 0x06013AC4 RID: 80580 RVA: 0x005DFAEF File Offset: 0x005DDEEF
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node55()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013AC5 RID: 80581 RVA: 0x005DFB24 File Offset: 0x005DDF24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D522 RID: 54562
		private int opl_p0;

		// Token: 0x0400D523 RID: 54563
		private int opl_p1;

		// Token: 0x0400D524 RID: 54564
		private int opl_p2;

		// Token: 0x0400D525 RID: 54565
		private int opl_p3;
	}
}
