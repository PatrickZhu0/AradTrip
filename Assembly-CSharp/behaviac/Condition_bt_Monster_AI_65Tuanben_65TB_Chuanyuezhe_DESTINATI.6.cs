using System;

namespace behaviac
{
	// Token: 0x02002B74 RID: 11124
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node12 : Condition
	{
		// Token: 0x06013FF5 RID: 81909 RVA: 0x006014D3 File Offset: 0x005FF8D3
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node12()
		{
			this.opl_p0 = 42770021;
		}

		// Token: 0x06013FF6 RID: 81910 RVA: 0x006014E8 File Offset: 0x005FF8E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA02 RID: 55810
		private int opl_p0;
	}
}
