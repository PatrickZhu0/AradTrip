using System;

namespace behaviac
{
	// Token: 0x02003731 RID: 14129
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node20 : Condition
	{
		// Token: 0x0601566F RID: 87663 RVA: 0x00674D88 File Offset: 0x00673188
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 12;
			bool flag = lastResult <= num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
