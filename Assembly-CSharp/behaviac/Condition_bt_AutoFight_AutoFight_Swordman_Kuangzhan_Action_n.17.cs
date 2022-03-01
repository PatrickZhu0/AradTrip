using System;

namespace behaviac
{
	// Token: 0x02002958 RID: 10584
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node56 : Condition
	{
		// Token: 0x06013BE5 RID: 80869 RVA: 0x005E73DD File Offset: 0x005E57DD
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node56()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013BE6 RID: 80870 RVA: 0x005E73F0 File Offset: 0x005E57F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D64C RID: 54860
		private float opl_p0;
	}
}
