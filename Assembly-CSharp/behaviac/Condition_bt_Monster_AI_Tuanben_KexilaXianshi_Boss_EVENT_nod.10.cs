using System;

namespace behaviac
{
	// Token: 0x02003A9D RID: 15005
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node112 : Condition
	{
		// Token: 0x06015CFF RID: 89343 RVA: 0x00696E7C File Offset: 0x0069527C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 2;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
