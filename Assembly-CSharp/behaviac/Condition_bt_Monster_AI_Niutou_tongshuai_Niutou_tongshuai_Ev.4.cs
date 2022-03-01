using System;

namespace behaviac
{
	// Token: 0x0200372D RID: 14125
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node12 : Condition
	{
		// Token: 0x06015667 RID: 87655 RVA: 0x00674C48 File Offset: 0x00673048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 6;
			bool flag = lastResult <= num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
