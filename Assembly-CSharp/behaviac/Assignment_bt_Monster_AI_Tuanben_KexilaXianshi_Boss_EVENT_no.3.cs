using System;

namespace behaviac
{
	// Token: 0x02003A9A RID: 15002
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node110 : Assignment
	{
		// Token: 0x06015CF9 RID: 89337 RVA: 0x00696DC4 File Offset: 0x006951C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
