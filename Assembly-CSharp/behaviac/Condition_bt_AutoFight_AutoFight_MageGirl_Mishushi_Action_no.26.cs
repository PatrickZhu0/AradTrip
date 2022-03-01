using System;

namespace behaviac
{
	// Token: 0x020026D1 RID: 9937
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node88 : Condition
	{
		// Token: 0x060136E5 RID: 79589 RVA: 0x005C9456 File Offset: 0x005C7856
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node88()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1500;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x060136E6 RID: 79590 RVA: 0x005C948C File Offset: 0x005C788C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D13B RID: 53563
		private int opl_p0;

		// Token: 0x0400D13C RID: 53564
		private int opl_p1;

		// Token: 0x0400D13D RID: 53565
		private int opl_p2;

		// Token: 0x0400D13E RID: 53566
		private int opl_p3;
	}
}
