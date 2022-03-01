using System;

namespace behaviac
{
	// Token: 0x02002314 RID: 8980
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node26 : Condition
	{
		// Token: 0x06012F9C RID: 77724 RVA: 0x0059C300 File Offset: 0x0059A700
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node26()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012F9D RID: 77725 RVA: 0x0059C314 File Offset: 0x0059A714
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9B5 RID: 51637
		private float opl_p0;
	}
}
