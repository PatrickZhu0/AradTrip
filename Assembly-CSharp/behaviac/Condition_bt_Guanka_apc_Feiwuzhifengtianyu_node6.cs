using System;

namespace behaviac
{
	// Token: 0x02002A2F RID: 10799
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node6 : Condition
	{
		// Token: 0x06013D8B RID: 81291 RVA: 0x005F1D77 File Offset: 0x005F0177
		public Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node6()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013D8C RID: 81292 RVA: 0x005F1D8C File Offset: 0x005F018C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7FB RID: 55291
		private float opl_p0;
	}
}
