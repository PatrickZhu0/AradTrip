using System;

namespace behaviac
{
	// Token: 0x02002B70 RID: 11120
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node11 : Condition
	{
		// Token: 0x06013FED RID: 81901 RVA: 0x006013B7 File Offset: 0x005FF7B7
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node11()
		{
			this.opl_p0 = 42770021;
		}

		// Token: 0x06013FEE RID: 81902 RVA: 0x006013CC File Offset: 0x005FF7CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9FC RID: 55804
		private int opl_p0;
	}
}
