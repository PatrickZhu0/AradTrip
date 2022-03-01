using System;

namespace behaviac
{
	// Token: 0x02002A52 RID: 10834
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node25 : Condition
	{
		// Token: 0x06013DCF RID: 81359 RVA: 0x005F3971 File Offset: 0x005F1D71
		public Condition_bt_Guanka_apc_guijian_feng_node25()
		{
			this.opl_p0 = 0.55f;
		}

		// Token: 0x06013DD0 RID: 81360 RVA: 0x005F3984 File Offset: 0x005F1D84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D844 RID: 55364
		private float opl_p0;
	}
}
