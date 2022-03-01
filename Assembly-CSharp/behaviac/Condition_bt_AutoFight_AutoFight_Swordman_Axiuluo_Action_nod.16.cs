using System;

namespace behaviac
{
	// Token: 0x020028AD RID: 10413
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node16 : Condition
	{
		// Token: 0x06013A94 RID: 80532 RVA: 0x005DF0AE File Offset: 0x005DD4AE
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node16()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013A95 RID: 80533 RVA: 0x005DF0E0 File Offset: 0x005DD4E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4F0 RID: 54512
		private int opl_p0;

		// Token: 0x0400D4F1 RID: 54513
		private int opl_p1;

		// Token: 0x0400D4F2 RID: 54514
		private int opl_p2;

		// Token: 0x0400D4F3 RID: 54515
		private int opl_p3;
	}
}
