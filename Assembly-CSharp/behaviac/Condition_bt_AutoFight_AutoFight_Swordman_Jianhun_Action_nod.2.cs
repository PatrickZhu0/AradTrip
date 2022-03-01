using System;

namespace behaviac
{
	// Token: 0x02002906 RID: 10502
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node97 : Condition
	{
		// Token: 0x06013B42 RID: 80706 RVA: 0x005E399D File Offset: 0x005E1D9D
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node97()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x06013B43 RID: 80707 RVA: 0x005E39B0 File Offset: 0x005E1DB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5A6 RID: 54694
		private float opl_p0;
	}
}
