using System;

namespace behaviac
{
	// Token: 0x020028F7 RID: 10487
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node74 : Condition
	{
		// Token: 0x06013B25 RID: 80677 RVA: 0x005E27AF File Offset: 0x005E0BAF
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node74()
		{
			this.opl_p0 = 4012;
		}

		// Token: 0x06013B26 RID: 80678 RVA: 0x005E27C4 File Offset: 0x005E0BC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D588 RID: 54664
		private int opl_p0;
	}
}
