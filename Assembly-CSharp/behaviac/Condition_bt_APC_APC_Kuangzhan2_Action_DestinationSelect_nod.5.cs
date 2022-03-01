using System;

namespace behaviac
{
	// Token: 0x02001D98 RID: 7576
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node50 : Condition
	{
		// Token: 0x060124EA RID: 74986 RVA: 0x00557E6F File Offset: 0x0055626F
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node50()
		{
			this.opl_p0 = 9701;
		}

		// Token: 0x060124EB RID: 74987 RVA: 0x00557E84 File Offset: 0x00556284
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BED5 RID: 48853
		private int opl_p0;
	}
}
