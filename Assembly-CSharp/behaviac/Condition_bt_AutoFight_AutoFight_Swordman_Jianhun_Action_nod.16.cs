using System;

namespace behaviac
{
	// Token: 0x02002918 RID: 10520
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node10 : Condition
	{
		// Token: 0x06013B66 RID: 80742 RVA: 0x005E4121 File Offset: 0x005E2521
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node10()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013B67 RID: 80743 RVA: 0x005E4134 File Offset: 0x005E2534
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5CC RID: 54732
		private float opl_p0;
	}
}
