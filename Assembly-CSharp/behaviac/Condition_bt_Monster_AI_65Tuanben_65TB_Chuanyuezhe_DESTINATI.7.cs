using System;

namespace behaviac
{
	// Token: 0x02002B75 RID: 11125
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node7 : Condition
	{
		// Token: 0x06013FF7 RID: 81911 RVA: 0x0060151E File Offset: 0x005FF91E
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node7()
		{
			this.opl_p0 = BE_Operation.LessThan;
			this.opl_p1 = 40000;
		}

		// Token: 0x06013FF8 RID: 81912 RVA: 0x00601538 File Offset: 0x005FF938
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_XDis(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA03 RID: 55811
		private BE_Operation opl_p0;

		// Token: 0x0400DA04 RID: 55812
		private int opl_p1;
	}
}
