using System;

namespace behaviac
{
	// Token: 0x020028FA RID: 10490
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node54 : Condition
	{
		// Token: 0x06013B2B RID: 80683 RVA: 0x005E291D File Offset: 0x005E0D1D
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node54()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013B2C RID: 80684 RVA: 0x005E2930 File Offset: 0x005E0D30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D58F RID: 54671
		private float opl_p0;
	}
}
