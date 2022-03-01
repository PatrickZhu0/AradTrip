using System;

namespace behaviac
{
	// Token: 0x02002B47 RID: 11079
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node39 : Condition
	{
		// Token: 0x06013F9C RID: 81820 RVA: 0x005FF1E6 File Offset: 0x005FD5E6
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node39()
		{
			this.opl_p0 = 21845;
		}

		// Token: 0x06013F9D RID: 81821 RVA: 0x005FF1FC File Offset: 0x005FD5FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9C0 RID: 55744
		private int opl_p0;
	}
}
