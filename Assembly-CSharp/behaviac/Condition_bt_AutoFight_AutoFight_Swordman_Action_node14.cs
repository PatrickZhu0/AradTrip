using System;

namespace behaviac
{
	// Token: 0x02002874 RID: 10356
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node14 : Condition
	{
		// Token: 0x06013A25 RID: 80421 RVA: 0x005DC8F2 File Offset: 0x005DACF2
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node14()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013A26 RID: 80422 RVA: 0x005DC908 File Offset: 0x005DAD08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D47E RID: 54398
		private float opl_p0;
	}
}
