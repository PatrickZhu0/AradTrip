using System;

namespace behaviac
{
	// Token: 0x020028B1 RID: 10417
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node70 : Condition
	{
		// Token: 0x06013A9C RID: 80540 RVA: 0x005DF25E File Offset: 0x005DD65E
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node70()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013A9D RID: 80541 RVA: 0x005DF290 File Offset: 0x005DD690
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4F8 RID: 54520
		private int opl_p0;

		// Token: 0x0400D4F9 RID: 54521
		private int opl_p1;

		// Token: 0x0400D4FA RID: 54522
		private int opl_p2;

		// Token: 0x0400D4FB RID: 54523
		private int opl_p3;
	}
}
