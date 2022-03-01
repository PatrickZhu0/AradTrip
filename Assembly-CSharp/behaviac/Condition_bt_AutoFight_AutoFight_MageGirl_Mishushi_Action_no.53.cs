using System;

namespace behaviac
{
	// Token: 0x020026F6 RID: 9974
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node21 : Condition
	{
		// Token: 0x0601372F RID: 79663 RVA: 0x005CA3E2 File Offset: 0x005C87E2
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node21()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013730 RID: 79664 RVA: 0x005CA418 File Offset: 0x005C8818
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D185 RID: 53637
		private int opl_p0;

		// Token: 0x0400D186 RID: 53638
		private int opl_p1;

		// Token: 0x0400D187 RID: 53639
		private int opl_p2;

		// Token: 0x0400D188 RID: 53640
		private int opl_p3;
	}
}
