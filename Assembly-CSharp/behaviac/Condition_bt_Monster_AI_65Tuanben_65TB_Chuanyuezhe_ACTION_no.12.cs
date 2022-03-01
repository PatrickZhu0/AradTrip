using System;

namespace behaviac
{
	// Token: 0x02002B4C RID: 11084
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node19 : Condition
	{
		// Token: 0x06013FA6 RID: 81830 RVA: 0x005FF6D5 File Offset: 0x005FDAD5
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node19()
		{
			this.opl_p0 = 21849;
		}

		// Token: 0x06013FA7 RID: 81831 RVA: 0x005FF6E8 File Offset: 0x005FDAE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9C7 RID: 55751
		private int opl_p0;
	}
}
