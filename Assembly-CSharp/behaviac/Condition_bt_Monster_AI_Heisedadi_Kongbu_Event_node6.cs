using System;

namespace behaviac
{
	// Token: 0x020034AD RID: 13485
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node6 : Condition
	{
		// Token: 0x060151A1 RID: 86433 RVA: 0x0065BEB8 File Offset: 0x0065A2B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
