using System;

namespace behaviac
{
	// Token: 0x0200327B RID: 12923
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node7 : Condition
	{
		// Token: 0x06014D73 RID: 85363 RVA: 0x00647218 File Offset: 0x00645618
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
