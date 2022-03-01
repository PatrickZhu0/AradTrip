using System;

namespace behaviac
{
	// Token: 0x020026DA RID: 9946
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node49 : Condition
	{
		// Token: 0x060136F7 RID: 79607 RVA: 0x005C97F6 File Offset: 0x005C7BF6
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node49()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 1500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060136F8 RID: 79608 RVA: 0x005C982C File Offset: 0x005C7C2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D14D RID: 53581
		private int opl_p0;

		// Token: 0x0400D14E RID: 53582
		private int opl_p1;

		// Token: 0x0400D14F RID: 53583
		private int opl_p2;

		// Token: 0x0400D150 RID: 53584
		private int opl_p3;
	}
}
