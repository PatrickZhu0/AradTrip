using System;

namespace behaviac
{
	// Token: 0x0200284B RID: 10315
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node81 : Condition
	{
		// Token: 0x060139D4 RID: 80340 RVA: 0x005D9CA2 File Offset: 0x005D80A2
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node81()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060139D5 RID: 80341 RVA: 0x005D9CD8 File Offset: 0x005D80D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D42C RID: 54316
		private int opl_p0;

		// Token: 0x0400D42D RID: 54317
		private int opl_p1;

		// Token: 0x0400D42E RID: 54318
		private int opl_p2;

		// Token: 0x0400D42F RID: 54319
		private int opl_p3;
	}
}
