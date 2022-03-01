using System;

namespace behaviac
{
	// Token: 0x02002A6C RID: 10860
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_sha_node4 : Condition
	{
		// Token: 0x06013DFF RID: 81407 RVA: 0x005F53FD File Offset: 0x005F37FD
		public Condition_bt_Guanka_apc_guijian_sha_node4()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013E00 RID: 81408 RVA: 0x005F5410 File Offset: 0x005F3810
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D872 RID: 55410
		private float opl_p0;
	}
}
