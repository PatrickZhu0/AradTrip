using System;

namespace behaviac
{
	// Token: 0x0200372A RID: 14122
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node8 : Condition
	{
		// Token: 0x06015661 RID: 87649 RVA: 0x00674B70 File Offset: 0x00672F70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 0;
			bool flag = lastResult > num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
