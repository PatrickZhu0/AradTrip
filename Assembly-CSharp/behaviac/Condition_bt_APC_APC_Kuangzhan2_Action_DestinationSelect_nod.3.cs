using System;

namespace behaviac
{
	// Token: 0x02001D96 RID: 7574
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node48 : Condition
	{
		// Token: 0x060124E6 RID: 74982 RVA: 0x00557DCD File Offset: 0x005561CD
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node48()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060124E7 RID: 74983 RVA: 0x00557DE0 File Offset: 0x005561E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BED1 RID: 48849
		private float opl_p0;
	}
}
