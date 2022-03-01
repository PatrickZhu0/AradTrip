using System;

namespace behaviac
{
	// Token: 0x020026A4 RID: 9892
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node31 : Condition
	{
		// Token: 0x0601368C RID: 79500 RVA: 0x005C7396 File Offset: 0x005C5796
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node31()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601368D RID: 79501 RVA: 0x005C73CC File Offset: 0x005C57CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0DF RID: 53471
		private int opl_p0;

		// Token: 0x0400D0E0 RID: 53472
		private int opl_p1;

		// Token: 0x0400D0E1 RID: 53473
		private int opl_p2;

		// Token: 0x0400D0E2 RID: 53474
		private int opl_p3;
	}
}
