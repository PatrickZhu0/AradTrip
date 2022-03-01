using System;

namespace behaviac
{
	// Token: 0x020029B7 RID: 10679
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node99 : Condition
	{
		// Token: 0x06013CA2 RID: 81058 RVA: 0x005EB07D File Offset: 0x005E947D
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node99()
		{
			this.opl_p0 = 1808;
		}

		// Token: 0x06013CA3 RID: 81059 RVA: 0x005EB090 File Offset: 0x005E9490
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D710 RID: 55056
		private int opl_p0;
	}
}
