using System;

namespace behaviac
{
	// Token: 0x02001D9B RID: 7579
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node6 : Condition
	{
		// Token: 0x060124F0 RID: 74992 RVA: 0x00557FDD File Offset: 0x005563DD
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node6()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060124F1 RID: 74993 RVA: 0x00557FF0 File Offset: 0x005563F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEDC RID: 48860
		private float opl_p0;
	}
}
