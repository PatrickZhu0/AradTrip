using System;

namespace behaviac
{
	// Token: 0x02002A9A RID: 10906
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node20 : Condition
	{
		// Token: 0x06013E56 RID: 81494 RVA: 0x005F7727 File Offset: 0x005F5B27
		public Condition_bt_Guanka_apc_Mofashi_li_node20()
		{
			this.opl_p0 = 2007;
		}

		// Token: 0x06013E57 RID: 81495 RVA: 0x005F773C File Offset: 0x005F5B3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8CB RID: 55499
		private int opl_p0;
	}
}
