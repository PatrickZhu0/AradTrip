using System;

namespace behaviac
{
	// Token: 0x020039C1 RID: 14785
	[GeneratedTypeMetaInfo]
	internal class Compute_bt_Monster_AI_Tuanben_Feiyi_Destination_node8 : Compute
	{
		// Token: 0x06015B55 RID: 88917 RVA: 0x0068E838 File Offset: 0x0068CC38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			((BTAgent)pAgent).bianshen = bianshen + num;
			return result;
		}
	}
}
