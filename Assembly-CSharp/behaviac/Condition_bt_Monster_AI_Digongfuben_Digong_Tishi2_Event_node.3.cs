using System;

namespace behaviac
{
	// Token: 0x02003277 RID: 12919
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node4 : Condition
	{
		// Token: 0x06014D6B RID: 85355 RVA: 0x00647138 File Offset: 0x00645538
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 3;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
