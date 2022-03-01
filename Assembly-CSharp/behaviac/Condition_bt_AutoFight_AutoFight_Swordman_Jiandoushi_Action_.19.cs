using System;

namespace behaviac
{
	// Token: 0x020028FB RID: 10491
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node57 : Condition
	{
		// Token: 0x06013B2D RID: 80685 RVA: 0x005E2963 File Offset: 0x005E0D63
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node57()
		{
			this.opl_p0 = 4013;
		}

		// Token: 0x06013B2E RID: 80686 RVA: 0x005E2978 File Offset: 0x005E0D78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D590 RID: 54672
		private int opl_p0;
	}
}
