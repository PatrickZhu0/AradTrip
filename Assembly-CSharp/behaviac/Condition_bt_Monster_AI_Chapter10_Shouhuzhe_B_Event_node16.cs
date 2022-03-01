using System;

namespace behaviac
{
	// Token: 0x02003140 RID: 12608
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node16 : Condition
	{
		// Token: 0x06014B23 RID: 84771 RVA: 0x0063B6CB File Offset: 0x00639ACB
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node16()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014B24 RID: 84772 RVA: 0x0063B6E0 File Offset: 0x00639AE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E49E RID: 58526
		private float opl_p0;
	}
}
