using System;

namespace behaviac
{
	// Token: 0x02003283 RID: 12931
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node4 : Condition
	{
		// Token: 0x06014D82 RID: 85378 RVA: 0x0064775C File Offset: 0x00645B5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 3;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
