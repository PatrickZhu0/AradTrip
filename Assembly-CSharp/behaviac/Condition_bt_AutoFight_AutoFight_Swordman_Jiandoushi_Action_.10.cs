using System;

namespace behaviac
{
	// Token: 0x020028EF RID: 10479
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node45 : Condition
	{
		// Token: 0x06013B15 RID: 80661 RVA: 0x005E2447 File Offset: 0x005E0847
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node45()
		{
			this.opl_p0 = 4007;
		}

		// Token: 0x06013B16 RID: 80662 RVA: 0x005E245C File Offset: 0x005E085C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D578 RID: 54648
		private int opl_p0;
	}
}
