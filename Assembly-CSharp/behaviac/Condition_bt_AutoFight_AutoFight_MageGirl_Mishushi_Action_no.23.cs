using System;

namespace behaviac
{
	// Token: 0x020026CD RID: 9933
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node83 : Condition
	{
		// Token: 0x060136DD RID: 79581 RVA: 0x005C92A2 File Offset: 0x005C76A2
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node83()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1500;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x060136DE RID: 79582 RVA: 0x005C92D8 File Offset: 0x005C76D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D133 RID: 53555
		private int opl_p0;

		// Token: 0x0400D134 RID: 53556
		private int opl_p1;

		// Token: 0x0400D135 RID: 53557
		private int opl_p2;

		// Token: 0x0400D136 RID: 53558
		private int opl_p3;
	}
}
