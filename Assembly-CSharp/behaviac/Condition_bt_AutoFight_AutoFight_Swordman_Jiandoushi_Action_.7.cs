using System;

namespace behaviac
{
	// Token: 0x020028EB RID: 10475
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node40 : Condition
	{
		// Token: 0x06013B0D RID: 80653 RVA: 0x005E2293 File Offset: 0x005E0693
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node40()
		{
			this.opl_p0 = 4005;
		}

		// Token: 0x06013B0E RID: 80654 RVA: 0x005E22A8 File Offset: 0x005E06A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D570 RID: 54640
		private int opl_p0;
	}
}
