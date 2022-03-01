using System;

namespace behaviac
{
	// Token: 0x02002B41 RID: 11073
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node35 : Condition
	{
		// Token: 0x06013F90 RID: 81808 RVA: 0x005FEF3B File Offset: 0x005FD33B
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node35()
		{
			this.opl_p0 = 21847;
		}

		// Token: 0x06013F91 RID: 81809 RVA: 0x005FEF50 File Offset: 0x005FD350
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9B5 RID: 55733
		private int opl_p0;
	}
}
