using System;

namespace behaviac
{
	// Token: 0x02003244 RID: 12868
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node4 : Condition
	{
		// Token: 0x06014D0A RID: 85258 RVA: 0x0064578C File Offset: 0x00643B8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
