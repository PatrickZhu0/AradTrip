using System;

namespace behaviac
{
	// Token: 0x020039D2 RID: 14802
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node48 : Assignment
	{
		// Token: 0x06015B75 RID: 88949 RVA: 0x0068F1A0 File Offset: 0x0068D5A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
