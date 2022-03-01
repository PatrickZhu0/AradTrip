using System;

namespace behaviac
{
	// Token: 0x02003145 RID: 12613
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node21 : Condition
	{
		// Token: 0x06014B2D RID: 84781 RVA: 0x0063B8BB File Offset: 0x00639CBB
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node21()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06014B2E RID: 84782 RVA: 0x0063B8D0 File Offset: 0x00639CD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4A7 RID: 58535
		private float opl_p0;
	}
}
