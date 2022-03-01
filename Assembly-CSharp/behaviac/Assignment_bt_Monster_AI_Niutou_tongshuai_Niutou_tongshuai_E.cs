using System;

namespace behaviac
{
	// Token: 0x02003729 RID: 14121
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node7 : Assignment
	{
		// Token: 0x0601565F RID: 87647 RVA: 0x00674B40 File Offset: 0x00672F40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int lastResult = ((BTAgent)pAgent).lastResult;
			((BTAgent)pAgent).compare = lastResult;
			return result;
		}
	}
}
