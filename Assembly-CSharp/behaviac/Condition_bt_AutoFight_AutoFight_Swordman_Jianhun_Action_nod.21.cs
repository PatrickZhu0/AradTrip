using System;

namespace behaviac
{
	// Token: 0x0200291F RID: 10527
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node63 : Condition
	{
		// Token: 0x06013B74 RID: 80756 RVA: 0x005E4605 File Offset: 0x005E2A05
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node63()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013B75 RID: 80757 RVA: 0x005E4618 File Offset: 0x005E2A18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5DB RID: 54747
		private float opl_p0;
	}
}
