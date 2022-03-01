using System;

namespace behaviac
{
	// Token: 0x02002771 RID: 10097
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node18 : Condition
	{
		// Token: 0x06013823 RID: 79907 RVA: 0x005D048F File Offset: 0x005CE88F
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node18()
		{
			this.opl_p0 = 2005;
		}

		// Token: 0x06013824 RID: 79908 RVA: 0x005D04A4 File Offset: 0x005CE8A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D284 RID: 53892
		private int opl_p0;
	}
}
