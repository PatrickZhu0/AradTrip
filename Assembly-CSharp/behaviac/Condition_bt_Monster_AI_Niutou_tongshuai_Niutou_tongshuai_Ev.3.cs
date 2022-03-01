using System;

namespace behaviac
{
	// Token: 0x0200372B RID: 14123
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node14 : Condition
	{
		// Token: 0x06015663 RID: 87651 RVA: 0x00674BA8 File Offset: 0x00672FA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 3;
			bool flag = lastResult <= num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
