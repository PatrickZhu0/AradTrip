using System;

namespace behaviac
{
	// Token: 0x02002A3C RID: 10812
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_cha_node13 : Condition
	{
		// Token: 0x06013DA4 RID: 81316 RVA: 0x005F2827 File Offset: 0x005F0C27
		public Condition_bt_Guanka_apc_guijian_cha_node13()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013DA5 RID: 81317 RVA: 0x005F283C File Offset: 0x005F0C3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D817 RID: 55319
		private float opl_p0;
	}
}
