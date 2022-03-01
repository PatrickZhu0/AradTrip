using System;

namespace behaviac
{
	// Token: 0x02001D95 RID: 7573
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node49 : Condition
	{
		// Token: 0x060124E4 RID: 74980 RVA: 0x00557D52 File Offset: 0x00556152
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node49()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060124E5 RID: 74981 RVA: 0x00557D88 File Offset: 0x00556188
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BECD RID: 48845
		private int opl_p0;

		// Token: 0x0400BECE RID: 48846
		private int opl_p1;

		// Token: 0x0400BECF RID: 48847
		private int opl_p2;

		// Token: 0x0400BED0 RID: 48848
		private int opl_p3;
	}
}
