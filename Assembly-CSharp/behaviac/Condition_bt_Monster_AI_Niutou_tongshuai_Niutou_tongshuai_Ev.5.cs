using System;

namespace behaviac
{
	// Token: 0x0200372F RID: 14127
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node17 : Condition
	{
		// Token: 0x0601566B RID: 87659 RVA: 0x00674CE8 File Offset: 0x006730E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 9;
			bool flag = lastResult <= num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
