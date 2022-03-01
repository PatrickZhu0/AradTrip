using System;

namespace behaviac
{
	// Token: 0x02001D9E RID: 7582
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node23 : Condition
	{
		// Token: 0x060124F6 RID: 74998 RVA: 0x00558116 File Offset: 0x00556516
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node23()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060124F7 RID: 74999 RVA: 0x00558148 File Offset: 0x00556548
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEE0 RID: 48864
		private int opl_p0;

		// Token: 0x0400BEE1 RID: 48865
		private int opl_p1;

		// Token: 0x0400BEE2 RID: 48866
		private int opl_p2;

		// Token: 0x0400BEE3 RID: 48867
		private int opl_p3;
	}
}
