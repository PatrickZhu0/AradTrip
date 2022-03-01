using System;

namespace behaviac
{
	// Token: 0x0200326B RID: 12907
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node4 : Condition
	{
		// Token: 0x06014D54 RID: 85332 RVA: 0x00646B14 File Offset: 0x00644F14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 3;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
