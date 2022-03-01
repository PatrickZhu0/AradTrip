using System;

namespace behaviac
{
	// Token: 0x02002A74 RID: 10868
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_sha_node19 : Condition
	{
		// Token: 0x06013E0F RID: 81423 RVA: 0x005F59A5 File Offset: 0x005F3DA5
		public Condition_bt_Guanka_apc_guijian_sha_node19()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013E10 RID: 81424 RVA: 0x005F59B8 File Offset: 0x005F3DB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D884 RID: 55428
		private float opl_p0;
	}
}
