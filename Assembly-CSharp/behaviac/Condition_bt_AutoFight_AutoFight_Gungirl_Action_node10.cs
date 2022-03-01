using System;

namespace behaviac
{
	// Token: 0x020024A5 RID: 9381
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node10 : Condition
	{
		// Token: 0x06013295 RID: 78485 RVA: 0x005AFF93 File Offset: 0x005AE393
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node10()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013296 RID: 78486 RVA: 0x005AFFC8 File Offset: 0x005AE3C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCAB RID: 52395
		private int opl_p0;

		// Token: 0x0400CCAC RID: 52396
		private int opl_p1;

		// Token: 0x0400CCAD RID: 52397
		private int opl_p2;

		// Token: 0x0400CCAE RID: 52398
		private int opl_p3;
	}
}
