using System;

namespace behaviac
{
	// Token: 0x0200351C RID: 13596
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node16 : Condition
	{
		// Token: 0x0601527B RID: 86651 RVA: 0x0065F5F3 File Offset: 0x0065D9F3
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node16()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x0601527C RID: 86652 RVA: 0x0065F608 File Offset: 0x0065DA08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBD7 RID: 60375
		private float opl_p0;
	}
}
