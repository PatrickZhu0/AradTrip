using System;

namespace behaviac
{
	// Token: 0x02002B69 RID: 11113
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node67 : Condition
	{
		// Token: 0x06013FE0 RID: 81888 RVA: 0x0060020A File Offset: 0x005FE60A
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node67()
		{
			this.opl_p0 = 21850;
		}

		// Token: 0x06013FE1 RID: 81889 RVA: 0x00600220 File Offset: 0x005FE620
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9F3 RID: 55795
		private int opl_p0;
	}
}
