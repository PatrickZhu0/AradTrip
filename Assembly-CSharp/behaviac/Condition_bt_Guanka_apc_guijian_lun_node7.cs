using System;

namespace behaviac
{
	// Token: 0x02002A67 RID: 10855
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_lun_node7 : Condition
	{
		// Token: 0x06013DF6 RID: 81398 RVA: 0x005F4DC3 File Offset: 0x005F31C3
		public Condition_bt_Guanka_apc_guijian_lun_node7()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013DF7 RID: 81399 RVA: 0x005F4DD8 File Offset: 0x005F31D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D86A RID: 55402
		private float opl_p0;
	}
}
