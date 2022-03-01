using System;

namespace behaviac
{
	// Token: 0x0200326C RID: 12908
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node15 : Condition
	{
		// Token: 0x06014D56 RID: 85334 RVA: 0x00646B4C File Offset: 0x00644F4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
