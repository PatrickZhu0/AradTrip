using System;

namespace behaviac
{
	// Token: 0x020028F3 RID: 10483
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node13 : Condition
	{
		// Token: 0x06013B1D RID: 80669 RVA: 0x005E25FB File Offset: 0x005E09FB
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node13()
		{
			this.opl_p0 = 4009;
		}

		// Token: 0x06013B1E RID: 80670 RVA: 0x005E2610 File Offset: 0x005E0A10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D580 RID: 54656
		private int opl_p0;
	}
}
