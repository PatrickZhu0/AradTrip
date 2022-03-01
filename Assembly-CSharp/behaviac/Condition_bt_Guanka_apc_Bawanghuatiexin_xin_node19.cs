using System;

namespace behaviac
{
	// Token: 0x02002A1C RID: 10780
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node19 : Condition
	{
		// Token: 0x06013D67 RID: 81255 RVA: 0x005F0B71 File Offset: 0x005EEF71
		public Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node19()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013D68 RID: 81256 RVA: 0x005F0B84 File Offset: 0x005EEF84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7D6 RID: 55254
		private float opl_p0;
	}
}
