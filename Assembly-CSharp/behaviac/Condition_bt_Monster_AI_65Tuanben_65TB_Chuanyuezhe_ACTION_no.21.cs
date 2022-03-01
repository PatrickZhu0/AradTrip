using System;

namespace behaviac
{
	// Token: 0x02002B5D RID: 11101
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node47 : Condition
	{
		// Token: 0x06013FC8 RID: 81864 RVA: 0x005FFDB2 File Offset: 0x005FE1B2
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node47()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06013FC9 RID: 81865 RVA: 0x005FFDC4 File Offset: 0x005FE1C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9E6 RID: 55782
		private int opl_p0;
	}
}
