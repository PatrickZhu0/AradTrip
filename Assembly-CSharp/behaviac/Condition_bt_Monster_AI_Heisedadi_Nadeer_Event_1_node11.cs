using System;

namespace behaviac
{
	// Token: 0x0200350F RID: 13583
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node11 : Condition
	{
		// Token: 0x06015261 RID: 86625 RVA: 0x0065F12F File Offset: 0x0065D52F
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node11()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06015262 RID: 86626 RVA: 0x0065F144 File Offset: 0x0065D544
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB9F RID: 60319
		private float opl_p0;
	}
}
