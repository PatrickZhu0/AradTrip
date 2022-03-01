using System;

namespace behaviac
{
	// Token: 0x02002266 RID: 8806
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node8 : Condition
	{
		// Token: 0x06012E52 RID: 77394 RVA: 0x005928E8 File Offset: 0x00590CE8
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node8()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012E53 RID: 77395 RVA: 0x005928FC File Offset: 0x00590CFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C860 RID: 51296
		private float opl_p0;
	}
}
