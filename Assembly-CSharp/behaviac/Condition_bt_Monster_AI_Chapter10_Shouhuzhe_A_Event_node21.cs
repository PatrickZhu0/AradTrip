using System;

namespace behaviac
{
	// Token: 0x02003130 RID: 12592
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node21 : Condition
	{
		// Token: 0x06014B05 RID: 84741 RVA: 0x0063ABD7 File Offset: 0x00638FD7
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node21()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06014B06 RID: 84742 RVA: 0x0063ABEC File Offset: 0x00638FEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E479 RID: 58489
		private float opl_p0;
	}
}
