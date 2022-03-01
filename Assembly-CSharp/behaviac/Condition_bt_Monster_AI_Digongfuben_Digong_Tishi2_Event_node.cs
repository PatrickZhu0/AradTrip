using System;

namespace behaviac
{
	// Token: 0x02003274 RID: 12916
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node11 : Condition
	{
		// Token: 0x06014D65 RID: 85349 RVA: 0x00647094 File Offset: 0x00645494
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
