using System;

namespace behaviac
{
	// Token: 0x02003257 RID: 12887
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node4 : Condition
	{
		// Token: 0x06014D2E RID: 85294 RVA: 0x006460C4 File Offset: 0x006444C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
