using System;

namespace behaviac
{
	// Token: 0x02002AC7 RID: 10951
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node28 : Condition
	{
		// Token: 0x06013EA9 RID: 81577 RVA: 0x005F9B0B File Offset: 0x005F7F0B
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node28()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013EAA RID: 81578 RVA: 0x005F9B20 File Offset: 0x005F7F20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D91D RID: 55581
		private float opl_p0;
	}
}
