using System;

namespace behaviac
{
	// Token: 0x02002A38 RID: 10808
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_cha_node6 : Condition
	{
		// Token: 0x06013D9C RID: 81308 RVA: 0x005F25A3 File Offset: 0x005F09A3
		public Condition_bt_Guanka_apc_guijian_cha_node6()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013D9D RID: 81309 RVA: 0x005F25B8 File Offset: 0x005F09B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D80D RID: 55309
		private float opl_p0;
	}
}
