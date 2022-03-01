using System;

namespace behaviac
{
	// Token: 0x02002A25 RID: 10789
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Cimeiguifeiyan_node11 : Condition
	{
		// Token: 0x06013D78 RID: 81272 RVA: 0x005F1349 File Offset: 0x005EF749
		public Condition_bt_Guanka_apc_Cimeiguifeiyan_node11()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013D79 RID: 81273 RVA: 0x005F135C File Offset: 0x005EF75C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7E8 RID: 55272
		private float opl_p0;
	}
}
