using System;

namespace behaviac
{
	// Token: 0x02002B71 RID: 11121
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node4 : Condition
	{
		// Token: 0x06013FEF RID: 81903 RVA: 0x00601402 File Offset: 0x005FF802
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node4()
		{
			this.opl_p0 = BE_Operation.LessThan;
			this.opl_p1 = 75000;
		}

		// Token: 0x06013FF0 RID: 81904 RVA: 0x0060141C File Offset: 0x005FF81C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_XDis(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9FD RID: 55805
		private BE_Operation opl_p0;

		// Token: 0x0400D9FE RID: 55806
		private int opl_p1;
	}
}
