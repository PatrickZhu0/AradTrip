using System;

namespace behaviac
{
	// Token: 0x02002A5C RID: 10844
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_jue_node11 : Condition
	{
		// Token: 0x06013DE2 RID: 81378 RVA: 0x005F4519 File Offset: 0x005F2919
		public Condition_bt_Guanka_apc_guijian_jue_node11()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013DE3 RID: 81379 RVA: 0x005F452C File Offset: 0x005F292C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D857 RID: 55383
		private float opl_p0;
	}
}
