using System;

namespace behaviac
{
	// Token: 0x020033F3 RID: 13299
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Emo2_Destination_node10 : Condition
	{
		// Token: 0x06015039 RID: 86073 RVA: 0x00654D0D File Offset: 0x0065310D
		public Condition_bt_Monster_AI_Heisedadi_Emo2_Destination_node10()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601503A RID: 86074 RVA: 0x00654D20 File Offset: 0x00653120
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E925 RID: 59685
		private float opl_p0;
	}
}
