using System;

namespace behaviac
{
	// Token: 0x02002B72 RID: 11122
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node10 : Condition
	{
		// Token: 0x06013FF1 RID: 81905 RVA: 0x00601455 File Offset: 0x005FF855
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node10()
		{
			this.opl_p0 = BE_Operation.GreaterThan;
			this.opl_p1 = 40000;
		}

		// Token: 0x06013FF2 RID: 81906 RVA: 0x00601470 File Offset: 0x005FF870
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_XDis(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9FF RID: 55807
		private BE_Operation opl_p0;

		// Token: 0x0400DA00 RID: 55808
		private int opl_p1;
	}
}
