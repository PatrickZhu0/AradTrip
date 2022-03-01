using System;

namespace behaviac
{
	// Token: 0x02002B54 RID: 11092
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node25 : Condition
	{
		// Token: 0x06013FB6 RID: 81846 RVA: 0x005FF9D5 File Offset: 0x005FDDD5
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node25()
		{
			this.opl_p0 = 21851;
		}

		// Token: 0x06013FB7 RID: 81847 RVA: 0x005FF9E8 File Offset: 0x005FDDE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9D5 RID: 55765
		private int opl_p0;
	}
}
