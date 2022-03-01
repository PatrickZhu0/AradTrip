using System;

namespace behaviac
{
	// Token: 0x02002AB6 RID: 10934
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_32_node11 : Condition
	{
		// Token: 0x06013E8A RID: 81546 RVA: 0x005F8E31 File Offset: 0x005F7231
		public Condition_bt_Guanka_apc_Shenqiangshou_32_node11()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013E8B RID: 81547 RVA: 0x005F8E44 File Offset: 0x005F7244
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8FF RID: 55551
		private float opl_p0;
	}
}
