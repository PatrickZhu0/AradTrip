using System;

namespace behaviac
{
	// Token: 0x02003A95 RID: 14997
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node88 : Condition
	{
		// Token: 0x06015CEF RID: 89327 RVA: 0x00696C9C File Offset: 0x0069509C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
