using System;

namespace behaviac
{
	// Token: 0x020039AF RID: 14767
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5 : Condition
	{
		// Token: 0x06015B32 RID: 88882 RVA: 0x0068DFB4 File Offset: 0x0068C3B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 11;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
