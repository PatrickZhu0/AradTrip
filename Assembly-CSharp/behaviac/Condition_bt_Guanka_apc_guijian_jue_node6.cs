using System;

namespace behaviac
{
	// Token: 0x02002A58 RID: 10840
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_jue_node6 : Condition
	{
		// Token: 0x06013DDA RID: 81370 RVA: 0x005F41F3 File Offset: 0x005F25F3
		public Condition_bt_Guanka_apc_guijian_jue_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013DDB RID: 81371 RVA: 0x005F4208 File Offset: 0x005F2608
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D84F RID: 55375
		private float opl_p0;
	}
}
