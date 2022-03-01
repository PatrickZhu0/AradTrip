using System;

namespace behaviac
{
	// Token: 0x02003701 RID: 14081
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node15 : Condition
	{
		// Token: 0x06015612 RID: 87570 RVA: 0x00673258 File Offset: 0x00671658
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int compare = ((BTAgent)pAgent).compare;
			bool flag = lastResult != compare;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
