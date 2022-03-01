using System;

namespace behaviac
{
	// Token: 0x02001D9A RID: 7578
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node15 : Condition
	{
		// Token: 0x060124EE RID: 74990 RVA: 0x00557F62 File Offset: 0x00556362
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node15()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x060124EF RID: 74991 RVA: 0x00557F98 File Offset: 0x00556398
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BED8 RID: 48856
		private int opl_p0;

		// Token: 0x0400BED9 RID: 48857
		private int opl_p1;

		// Token: 0x0400BEDA RID: 48858
		private int opl_p2;

		// Token: 0x0400BEDB RID: 48859
		private int opl_p3;
	}
}
