using System;

namespace behaviac
{
	// Token: 0x0200337C RID: 13180
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node5 : Assignment
	{
		// Token: 0x06014F56 RID: 85846 RVA: 0x00650880 File Offset: 0x0064EC80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
