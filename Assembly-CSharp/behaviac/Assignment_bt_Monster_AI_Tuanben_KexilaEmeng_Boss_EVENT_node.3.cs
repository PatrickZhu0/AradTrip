using System;

namespace behaviac
{
	// Token: 0x02003A07 RID: 14855
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node17 : Assignment
	{
		// Token: 0x06015BDD RID: 89053 RVA: 0x00690E9C File Offset: 0x0068F29C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
