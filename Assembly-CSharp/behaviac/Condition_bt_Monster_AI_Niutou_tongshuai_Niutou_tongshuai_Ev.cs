using System;

namespace behaviac
{
	// Token: 0x02003724 RID: 14116
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node2 : Condition
	{
		// Token: 0x06015655 RID: 87637 RVA: 0x00674A10 File Offset: 0x00672E10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int compare = ((BTAgent)pAgent).compare;
			bool flag = lastResult != compare;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
