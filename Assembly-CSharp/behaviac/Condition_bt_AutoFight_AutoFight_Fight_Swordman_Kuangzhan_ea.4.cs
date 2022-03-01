using System;

namespace behaviac
{
	// Token: 0x02002309 RID: 8969
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node11 : Condition
	{
		// Token: 0x06012F88 RID: 77704 RVA: 0x0059BE10 File Offset: 0x0059A210
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node11()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06012F89 RID: 77705 RVA: 0x0059BE24 File Offset: 0x0059A224
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9A2 RID: 51618
		private float opl_p0;
	}
}
