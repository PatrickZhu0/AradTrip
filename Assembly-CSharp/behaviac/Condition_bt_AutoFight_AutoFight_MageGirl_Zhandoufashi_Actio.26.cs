using System;

namespace behaviac
{
	// Token: 0x02002722 RID: 10018
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node50 : Condition
	{
		// Token: 0x06013786 RID: 79750 RVA: 0x005CCDC7 File Offset: 0x005CB1C7
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node50()
		{
			this.opl_p0 = 2311;
		}

		// Token: 0x06013787 RID: 79751 RVA: 0x005CCDDC File Offset: 0x005CB1DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1E0 RID: 53728
		private int opl_p0;
	}
}
