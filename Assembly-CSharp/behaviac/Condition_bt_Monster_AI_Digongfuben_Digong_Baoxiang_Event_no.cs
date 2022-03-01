using System;

namespace behaviac
{
	// Token: 0x02003238 RID: 12856
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node4 : Condition
	{
		// Token: 0x06014CF3 RID: 85235 RVA: 0x006451A0 File Offset: 0x006435A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
