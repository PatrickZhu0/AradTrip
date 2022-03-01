using System;

namespace behaviac
{
	// Token: 0x02002ACF RID: 10959
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node24 : Condition
	{
		// Token: 0x06013EB9 RID: 81593 RVA: 0x005FA041 File Offset: 0x005F8441
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node24()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013EBA RID: 81594 RVA: 0x005FA054 File Offset: 0x005F8454
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D92D RID: 55597
		private float opl_p0;
	}
}
