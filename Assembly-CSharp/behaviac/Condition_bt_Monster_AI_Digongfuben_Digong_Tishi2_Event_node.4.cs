using System;

namespace behaviac
{
	// Token: 0x02003278 RID: 12920
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node15 : Condition
	{
		// Token: 0x06014D6D RID: 85357 RVA: 0x00647170 File Offset: 0x00645570
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
