using System;

namespace behaviac
{
	// Token: 0x0200312B RID: 12587
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node16 : Condition
	{
		// Token: 0x06014AFB RID: 84731 RVA: 0x0063A9E7 File Offset: 0x00638DE7
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node16()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014AFC RID: 84732 RVA: 0x0063A9FC File Offset: 0x00638DFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E470 RID: 58480
		private float opl_p0;
	}
}
