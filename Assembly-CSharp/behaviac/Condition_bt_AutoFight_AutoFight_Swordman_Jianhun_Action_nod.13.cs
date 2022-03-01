using System;

namespace behaviac
{
	// Token: 0x02002914 RID: 10516
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node19 : Condition
	{
		// Token: 0x06013B5E RID: 80734 RVA: 0x005E3F6D File Offset: 0x005E236D
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node19()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x06013B5F RID: 80735 RVA: 0x005E3F80 File Offset: 0x005E2380
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5C4 RID: 54724
		private float opl_p0;
	}
}
