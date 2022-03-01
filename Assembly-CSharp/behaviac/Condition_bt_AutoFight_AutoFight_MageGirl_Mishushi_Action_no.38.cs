using System;

namespace behaviac
{
	// Token: 0x020026E2 RID: 9954
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node27 : Condition
	{
		// Token: 0x06013707 RID: 79623 RVA: 0x005C9B5E File Offset: 0x005C7F5E
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node27()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x06013708 RID: 79624 RVA: 0x005C9B94 File Offset: 0x005C7F94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D15D RID: 53597
		private int opl_p0;

		// Token: 0x0400D15E RID: 53598
		private int opl_p1;

		// Token: 0x0400D15F RID: 53599
		private int opl_p2;

		// Token: 0x0400D160 RID: 53600
		private int opl_p3;
	}
}
