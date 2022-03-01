using System;

namespace behaviac
{
	// Token: 0x02003A99 RID: 15001
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node111 : Condition
	{
		// Token: 0x06015CF7 RID: 89335 RVA: 0x00696D8C File Offset: 0x0069518C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
