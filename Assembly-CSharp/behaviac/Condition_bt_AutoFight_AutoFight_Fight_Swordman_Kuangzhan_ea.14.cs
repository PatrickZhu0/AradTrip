using System;

namespace behaviac
{
	// Token: 0x02002319 RID: 8985
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node33 : Condition
	{
		// Token: 0x06012FA5 RID: 77733 RVA: 0x0059C51C File Offset: 0x0059A91C
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node33()
		{
			this.opl_p0 = 0.44f;
		}

		// Token: 0x06012FA6 RID: 77734 RVA: 0x0059C530 File Offset: 0x0059A930
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9BD RID: 51645
		private float opl_p0;
	}
}
