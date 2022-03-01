using System;

namespace behaviac
{
	// Token: 0x02002AA7 RID: 10919
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_wei_node11 : Condition
	{
		// Token: 0x06013E6E RID: 81518 RVA: 0x005F825D File Offset: 0x005F665D
		public Condition_bt_Guanka_apc_Mofashi_wei_node11()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013E6F RID: 81519 RVA: 0x005F8270 File Offset: 0x005F6670
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8E4 RID: 55524
		private float opl_p0;
	}
}
