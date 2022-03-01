using System;

namespace behaviac
{
	// Token: 0x020033F5 RID: 13301
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Emo2_Destination_node14 : Condition
	{
		// Token: 0x0601503D RID: 86077 RVA: 0x00654D7D File Offset: 0x0065317D
		public Condition_bt_Monster_AI_Heisedadi_Emo2_Destination_node14()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601503E RID: 86078 RVA: 0x00654D90 File Offset: 0x00653190
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E927 RID: 59687
		private float opl_p0;
	}
}
