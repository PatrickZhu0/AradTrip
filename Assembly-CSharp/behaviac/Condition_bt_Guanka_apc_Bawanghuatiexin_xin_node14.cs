using System;

namespace behaviac
{
	// Token: 0x02002A19 RID: 10777
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node14 : Condition
	{
		// Token: 0x06013D61 RID: 81249 RVA: 0x005F08EF File Offset: 0x005EECEF
		public Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node14()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013D62 RID: 81250 RVA: 0x005F0904 File Offset: 0x005EED04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7CF RID: 55247
		private float opl_p0;
	}
}
