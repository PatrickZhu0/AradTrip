using System;

namespace behaviac
{
	// Token: 0x02002A99 RID: 10905
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node19 : Condition
	{
		// Token: 0x06013E54 RID: 81492 RVA: 0x005F76E1 File Offset: 0x005F5AE1
		public Condition_bt_Guanka_apc_Mofashi_li_node19()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013E55 RID: 81493 RVA: 0x005F76F4 File Offset: 0x005F5AF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8CA RID: 55498
		private float opl_p0;
	}
}
