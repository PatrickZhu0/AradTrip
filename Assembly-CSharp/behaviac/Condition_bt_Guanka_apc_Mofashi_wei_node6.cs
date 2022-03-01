using System;

namespace behaviac
{
	// Token: 0x02002AA4 RID: 10916
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_wei_node6 : Condition
	{
		// Token: 0x06013E68 RID: 81512 RVA: 0x005F80EF File Offset: 0x005F64EF
		public Condition_bt_Guanka_apc_Mofashi_wei_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013E69 RID: 81513 RVA: 0x005F8104 File Offset: 0x005F6504
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8DD RID: 55517
		private float opl_p0;
	}
}
