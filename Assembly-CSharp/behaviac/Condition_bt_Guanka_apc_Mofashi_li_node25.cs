using System;

namespace behaviac
{
	// Token: 0x02002A9E RID: 10910
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node25 : Condition
	{
		// Token: 0x06013E5E RID: 81502 RVA: 0x005F78DB File Offset: 0x005F5CDB
		public Condition_bt_Guanka_apc_Mofashi_li_node25()
		{
			this.opl_p0 = 2510;
		}

		// Token: 0x06013E5F RID: 81503 RVA: 0x005F78F0 File Offset: 0x005F5CF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8D3 RID: 55507
		private int opl_p0;
	}
}
