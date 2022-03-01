using System;

namespace behaviac
{
	// Token: 0x02002902 RID: 10498
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node10 : Condition
	{
		// Token: 0x06013B3B RID: 80699 RVA: 0x005E2C85 File Offset: 0x005E1085
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node10()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013B3C RID: 80700 RVA: 0x005E2C98 File Offset: 0x005E1098
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D59F RID: 54687
		private float opl_p0;
	}
}
