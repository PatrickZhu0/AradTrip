using System;

namespace behaviac
{
	// Token: 0x020027A1 RID: 10145
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node24 : Condition
	{
		// Token: 0x06013882 RID: 80002 RVA: 0x005D2B3B File Offset: 0x005D0F3B
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node24()
		{
			this.opl_p0 = 3506;
		}

		// Token: 0x06013883 RID: 80003 RVA: 0x005D2B50 File Offset: 0x005D0F50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2E2 RID: 53986
		private int opl_p0;
	}
}
