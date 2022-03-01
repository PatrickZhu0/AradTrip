using System;

namespace behaviac
{
	// Token: 0x02002B6E RID: 11118
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node1 : Condition
	{
		// Token: 0x06013FE9 RID: 81897 RVA: 0x0060133A File Offset: 0x005FF73A
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node1()
		{
			this.opl_p0 = BE_Operation.GreaterThan;
			this.opl_p1 = 75000;
		}

		// Token: 0x06013FEA RID: 81898 RVA: 0x00601354 File Offset: 0x005FF754
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_XDis(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9F9 RID: 55801
		private BE_Operation opl_p0;

		// Token: 0x0400D9FA RID: 55802
		private int opl_p1;
	}
}
