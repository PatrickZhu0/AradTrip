using System;

namespace behaviac
{
	// Token: 0x02003400 RID: 13312
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node14 : Condition
	{
		// Token: 0x06015052 RID: 86098 RVA: 0x00655395 File Offset: 0x00653795
		public Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node14()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015053 RID: 86099 RVA: 0x006553A8 File Offset: 0x006537A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E935 RID: 59701
		private float opl_p0;
	}
}
