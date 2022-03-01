using System;

namespace behaviac
{
	// Token: 0x02002AB2 RID: 10930
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_32_node6 : Condition
	{
		// Token: 0x06013E82 RID: 81538 RVA: 0x005F8B0B File Offset: 0x005F6F0B
		public Condition_bt_Guanka_apc_Shenqiangshou_32_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013E83 RID: 81539 RVA: 0x005F8B20 File Offset: 0x005F6F20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8F7 RID: 55543
		private float opl_p0;
	}
}
