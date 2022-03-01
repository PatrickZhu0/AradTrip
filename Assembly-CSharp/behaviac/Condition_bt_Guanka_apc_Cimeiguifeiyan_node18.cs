using System;

namespace behaviac
{
	// Token: 0x02002A2A RID: 10794
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Cimeiguifeiyan_node18 : Condition
	{
		// Token: 0x06013D82 RID: 81282 RVA: 0x005F170F File Offset: 0x005EFB0F
		public Condition_bt_Guanka_apc_Cimeiguifeiyan_node18()
		{
			this.opl_p0 = 2517;
		}

		// Token: 0x06013D83 RID: 81283 RVA: 0x005F1724 File Offset: 0x005EFB24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7F1 RID: 55281
		private int opl_p0;
	}
}
