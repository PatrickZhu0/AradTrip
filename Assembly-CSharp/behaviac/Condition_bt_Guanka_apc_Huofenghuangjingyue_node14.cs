using System;

namespace behaviac
{
	// Token: 0x02002A7E RID: 10878
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Huofenghuangjingyue_node14 : Condition
	{
		// Token: 0x06013E22 RID: 81442 RVA: 0x005F63D3 File Offset: 0x005F47D3
		public Condition_bt_Guanka_apc_Huofenghuangjingyue_node14()
		{
			this.opl_p0 = 2513;
		}

		// Token: 0x06013E23 RID: 81443 RVA: 0x005F63E8 File Offset: 0x005F47E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D897 RID: 55447
		private int opl_p0;
	}
}
