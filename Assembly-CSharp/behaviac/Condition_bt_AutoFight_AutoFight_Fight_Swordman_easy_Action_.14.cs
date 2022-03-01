using System;

namespace behaviac
{
	// Token: 0x02002279 RID: 8825
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node30 : Condition
	{
		// Token: 0x06012E76 RID: 77430 RVA: 0x00593166 File Offset: 0x00591566
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node30()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012E77 RID: 77431 RVA: 0x0059317C File Offset: 0x0059157C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C882 RID: 51330
		private float opl_p0;
	}
}
