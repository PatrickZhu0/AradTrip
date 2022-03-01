using System;

namespace behaviac
{
	// Token: 0x02003536 RID: 13622
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node20 : Condition
	{
		// Token: 0x060152AF RID: 86703 RVA: 0x0065FF7B File Offset: 0x0065E37B
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node20()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060152B0 RID: 86704 RVA: 0x0065FF90 File Offset: 0x0065E390
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC47 RID: 60487
		private float opl_p0;
	}
}
