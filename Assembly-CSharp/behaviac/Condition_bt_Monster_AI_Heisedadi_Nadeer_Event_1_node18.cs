using System;

namespace behaviac
{
	// Token: 0x02003529 RID: 13609
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node18 : Condition
	{
		// Token: 0x06015295 RID: 86677 RVA: 0x0065FAB7 File Offset: 0x0065DEB7
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node18()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015296 RID: 86678 RVA: 0x0065FACC File Offset: 0x0065DECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC0F RID: 60431
		private float opl_p0;
	}
}
