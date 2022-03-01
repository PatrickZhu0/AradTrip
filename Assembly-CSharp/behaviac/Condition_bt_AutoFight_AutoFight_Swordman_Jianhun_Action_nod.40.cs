using System;

namespace behaviac
{
	// Token: 0x0200293A RID: 10554
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node23 : Condition
	{
		// Token: 0x06013BAA RID: 80810 RVA: 0x005E54F7 File Offset: 0x005E38F7
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013BAB RID: 80811 RVA: 0x005E552C File Offset: 0x005E392C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D60F RID: 54799
		private int opl_p0;

		// Token: 0x0400D610 RID: 54800
		private int opl_p1;

		// Token: 0x0400D611 RID: 54801
		private int opl_p2;

		// Token: 0x0400D612 RID: 54802
		private int opl_p3;
	}
}
