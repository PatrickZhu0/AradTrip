using System;

namespace behaviac
{
	// Token: 0x02002A92 RID: 10898
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node6 : Condition
	{
		// Token: 0x06013E46 RID: 81478 RVA: 0x005F73BF File Offset: 0x005F57BF
		public Condition_bt_Guanka_apc_Mofashi_li_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013E47 RID: 81479 RVA: 0x005F73D4 File Offset: 0x005F57D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8BB RID: 55483
		private float opl_p0;
	}
}
