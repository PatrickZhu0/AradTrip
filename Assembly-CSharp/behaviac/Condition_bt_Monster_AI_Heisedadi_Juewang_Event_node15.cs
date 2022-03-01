using System;

namespace behaviac
{
	// Token: 0x02003476 RID: 13430
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node15 : Condition
	{
		// Token: 0x06015136 RID: 86326 RVA: 0x00659E90 File Offset: 0x00658290
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 4;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
