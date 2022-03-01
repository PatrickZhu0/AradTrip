using System;

namespace behaviac
{
	// Token: 0x0200271E RID: 10014
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node45 : Condition
	{
		// Token: 0x0601377E RID: 79742 RVA: 0x005CCC13 File Offset: 0x005CB013
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node45()
		{
			this.opl_p0 = 2309;
		}

		// Token: 0x0601377F RID: 79743 RVA: 0x005CCC28 File Offset: 0x005CB028
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1D8 RID: 53720
		private int opl_p0;
	}
}
