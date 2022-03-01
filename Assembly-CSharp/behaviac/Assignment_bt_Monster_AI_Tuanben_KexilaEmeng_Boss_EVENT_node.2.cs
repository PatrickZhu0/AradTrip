using System;

namespace behaviac
{
	// Token: 0x02003A03 RID: 14851
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node10 : Assignment
	{
		// Token: 0x06015BD5 RID: 89045 RVA: 0x00690DBC File Offset: 0x0068F1BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
