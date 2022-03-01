using System;

namespace behaviac
{
	// Token: 0x02002A26 RID: 10790
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Cimeiguifeiyan_node12 : Condition
	{
		// Token: 0x06013D7A RID: 81274 RVA: 0x005F138F File Offset: 0x005EF78F
		public Condition_bt_Guanka_apc_Cimeiguifeiyan_node12()
		{
			this.opl_p0 = 2519;
		}

		// Token: 0x06013D7B RID: 81275 RVA: 0x005F13A4 File Offset: 0x005EF7A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7E9 RID: 55273
		private int opl_p0;
	}
}
