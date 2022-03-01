using System;

namespace behaviac
{
	// Token: 0x0200290D RID: 10509
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node59 : Condition
	{
		// Token: 0x06013B50 RID: 80720 RVA: 0x005E3C4F File Offset: 0x005E204F
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node59()
		{
			this.opl_p0 = 1906;
		}

		// Token: 0x06013B51 RID: 80721 RVA: 0x005E3C64 File Offset: 0x005E2064
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5B5 RID: 54709
		private int opl_p0;
	}
}
