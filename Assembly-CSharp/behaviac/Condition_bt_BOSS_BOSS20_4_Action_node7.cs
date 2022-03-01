using System;

namespace behaviac
{
	// Token: 0x020029E2 RID: 10722
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node7 : Condition
	{
		// Token: 0x06013CF7 RID: 81143 RVA: 0x005EDFB6 File Offset: 0x005EC3B6
		public Condition_bt_BOSS_BOSS20_4_Action_node7()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06013CF8 RID: 81144 RVA: 0x005EDFEC File Offset: 0x005EC3EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D769 RID: 55145
		private int opl_p0;

		// Token: 0x0400D76A RID: 55146
		private int opl_p1;

		// Token: 0x0400D76B RID: 55147
		private int opl_p2;

		// Token: 0x0400D76C RID: 55148
		private int opl_p3;
	}
}
