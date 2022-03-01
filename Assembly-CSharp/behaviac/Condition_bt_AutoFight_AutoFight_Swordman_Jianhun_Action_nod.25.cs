using System;

namespace behaviac
{
	// Token: 0x02002924 RID: 10532
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node77 : Condition
	{
		// Token: 0x06013B7E RID: 80766 RVA: 0x005E485B File Offset: 0x005E2C5B
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node77()
		{
			this.opl_p0 = 1933;
		}

		// Token: 0x06013B7F RID: 80767 RVA: 0x005E4870 File Offset: 0x005E2C70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5E4 RID: 54756
		private int opl_p0;
	}
}
