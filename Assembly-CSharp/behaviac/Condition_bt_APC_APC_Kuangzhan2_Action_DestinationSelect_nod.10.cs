using System;

namespace behaviac
{
	// Token: 0x02001D9F RID: 7583
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node26 : Condition
	{
		// Token: 0x060124F8 RID: 75000 RVA: 0x0055818D File Offset: 0x0055658D
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node26()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060124F9 RID: 75001 RVA: 0x005581A0 File Offset: 0x005565A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEE4 RID: 48868
		private float opl_p0;
	}
}
