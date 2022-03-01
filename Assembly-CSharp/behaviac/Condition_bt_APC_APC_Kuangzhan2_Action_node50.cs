using System;

namespace behaviac
{
	// Token: 0x02001D81 RID: 7553
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node50 : Condition
	{
		// Token: 0x060124BD RID: 74941 RVA: 0x00556BE3 File Offset: 0x00554FE3
		public Condition_bt_APC_APC_Kuangzhan2_Action_node50()
		{
			this.opl_p0 = 9715;
		}

		// Token: 0x060124BE RID: 74942 RVA: 0x00556BF8 File Offset: 0x00554FF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEA8 RID: 48808
		private int opl_p0;
	}
}
