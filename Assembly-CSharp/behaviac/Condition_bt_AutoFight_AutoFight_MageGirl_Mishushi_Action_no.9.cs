using System;

namespace behaviac
{
	// Token: 0x020026BA RID: 9914
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node2 : Condition
	{
		// Token: 0x060136B7 RID: 79543 RVA: 0x005C8A66 File Offset: 0x005C6E66
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node2()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060136B8 RID: 79544 RVA: 0x005C8A9C File Offset: 0x005C6E9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D10C RID: 53516
		private int opl_p0;

		// Token: 0x0400D10D RID: 53517
		private int opl_p1;

		// Token: 0x0400D10E RID: 53518
		private int opl_p2;

		// Token: 0x0400D10F RID: 53519
		private int opl_p3;
	}
}
