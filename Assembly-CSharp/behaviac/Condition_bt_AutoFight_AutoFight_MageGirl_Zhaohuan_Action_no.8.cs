using System;

namespace behaviac
{
	// Token: 0x02002751 RID: 10065
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node54 : Condition
	{
		// Token: 0x060137E3 RID: 79843 RVA: 0x005CF65D File Offset: 0x005CDA5D
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node54()
		{
			this.opl_p0 = 2103;
		}

		// Token: 0x060137E4 RID: 79844 RVA: 0x005CF670 File Offset: 0x005CDA70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D240 RID: 53824
		private int opl_p0;
	}
}
