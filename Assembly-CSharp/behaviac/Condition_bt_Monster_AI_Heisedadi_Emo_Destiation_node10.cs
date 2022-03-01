using System;

namespace behaviac
{
	// Token: 0x020033FE RID: 13310
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node10 : Condition
	{
		// Token: 0x0601504E RID: 86094 RVA: 0x00655325 File Offset: 0x00653725
		public Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node10()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601504F RID: 86095 RVA: 0x00655338 File Offset: 0x00653738
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E933 RID: 59699
		private float opl_p0;
	}
}
