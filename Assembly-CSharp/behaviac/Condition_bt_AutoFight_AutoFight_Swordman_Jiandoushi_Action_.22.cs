using System;

namespace behaviac
{
	// Token: 0x020028FF RID: 10495
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node20 : Condition
	{
		// Token: 0x06013B35 RID: 80693 RVA: 0x005E2B17 File Offset: 0x005E0F17
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node20()
		{
			this.opl_p0 = 4006;
		}

		// Token: 0x06013B36 RID: 80694 RVA: 0x005E2B2C File Offset: 0x005E0F2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D598 RID: 54680
		private int opl_p0;
	}
}
