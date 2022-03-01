using System;

namespace behaviac
{
	// Token: 0x02002A53 RID: 10835
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node26 : Condition
	{
		// Token: 0x06013DD1 RID: 81361 RVA: 0x005F39B7 File Offset: 0x005F1DB7
		public Condition_bt_Guanka_apc_guijian_feng_node26()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x06013DD2 RID: 81362 RVA: 0x005F39CC File Offset: 0x005F1DCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D845 RID: 55365
		private int opl_p0;
	}
}
