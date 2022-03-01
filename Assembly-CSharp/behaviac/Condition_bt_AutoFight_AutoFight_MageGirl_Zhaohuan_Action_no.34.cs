using System;

namespace behaviac
{
	// Token: 0x02002775 RID: 10101
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node71 : Condition
	{
		// Token: 0x0601382B RID: 79915 RVA: 0x005D0643 File Offset: 0x005CEA43
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node71()
		{
			this.opl_p0 = 2008;
		}

		// Token: 0x0601382C RID: 79916 RVA: 0x005D0658 File Offset: 0x005CEA58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D28C RID: 53900
		private int opl_p0;
	}
}
