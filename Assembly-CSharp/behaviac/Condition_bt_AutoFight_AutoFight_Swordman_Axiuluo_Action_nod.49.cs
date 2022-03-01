using System;

namespace behaviac
{
	// Token: 0x020028D7 RID: 10455
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node77 : Condition
	{
		// Token: 0x06013AE8 RID: 80616 RVA: 0x005E0337 File Offset: 0x005DE737
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node77()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013AE9 RID: 80617 RVA: 0x005E036C File Offset: 0x005DE76C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D548 RID: 54600
		private int opl_p0;

		// Token: 0x0400D549 RID: 54601
		private int opl_p1;

		// Token: 0x0400D54A RID: 54602
		private int opl_p2;

		// Token: 0x0400D54B RID: 54603
		private int opl_p3;
	}
}
