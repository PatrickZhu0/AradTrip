using System;

namespace behaviac
{
	// Token: 0x020029B3 RID: 10675
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node105 : Condition
	{
		// Token: 0x06013C9A RID: 81050 RVA: 0x005EAEC7 File Offset: 0x005E92C7
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node105()
		{
			this.opl_p0 = 1805;
		}

		// Token: 0x06013C9B RID: 81051 RVA: 0x005EAEDC File Offset: 0x005E92DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D708 RID: 55048
		private int opl_p0;
	}
}
