using System;

namespace behaviac
{
	// Token: 0x02002A0C RID: 10764
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_node7 : Condition
	{
		// Token: 0x06013D48 RID: 81224 RVA: 0x005EFC0B File Offset: 0x005EE00B
		public Condition_bt_Guanka_apc_Bawanghuatiexin_node7()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013D49 RID: 81225 RVA: 0x005EFC20 File Offset: 0x005EE020
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7B3 RID: 55219
		private float opl_p0;
	}
}
