using System;

namespace behaviac
{
	// Token: 0x02002B67 RID: 11111
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node64 : Condition
	{
		// Token: 0x06013FDC RID: 81884 RVA: 0x00600116 File Offset: 0x005FE516
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node64()
		{
			this.opl_p0 = 21851;
		}

		// Token: 0x06013FDD RID: 81885 RVA: 0x0060012C File Offset: 0x005FE52C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9F0 RID: 55792
		private int opl_p0;
	}
}
