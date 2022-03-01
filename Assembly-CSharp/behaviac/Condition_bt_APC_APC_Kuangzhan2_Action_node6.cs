using System;

namespace behaviac
{
	// Token: 0x02001D84 RID: 7556
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node6 : Condition
	{
		// Token: 0x060124C3 RID: 74947 RVA: 0x00556F7D File Offset: 0x0055537D
		public Condition_bt_APC_APC_Kuangzhan2_Action_node6()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060124C4 RID: 74948 RVA: 0x00556F90 File Offset: 0x00555390
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEAF RID: 48815
		private float opl_p0;
	}
}
