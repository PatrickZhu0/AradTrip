using System;

namespace behaviac
{
	// Token: 0x020025D1 RID: 9681
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node13 : Condition
	{
		// Token: 0x060134E9 RID: 79081 RVA: 0x005BD4EB File Offset: 0x005BB8EB
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node13()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060134EA RID: 79082 RVA: 0x005BD520 File Offset: 0x005BB920
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF2D RID: 53037
		private int opl_p0;

		// Token: 0x0400CF2E RID: 53038
		private int opl_p1;

		// Token: 0x0400CF2F RID: 53039
		private int opl_p2;

		// Token: 0x0400CF30 RID: 53040
		private int opl_p3;
	}
}
