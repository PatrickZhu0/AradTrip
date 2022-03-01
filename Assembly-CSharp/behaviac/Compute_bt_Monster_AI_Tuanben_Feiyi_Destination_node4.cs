using System;

namespace behaviac
{
	// Token: 0x020039BE RID: 14782
	[GeneratedTypeMetaInfo]
	internal class Compute_bt_Monster_AI_Tuanben_Feiyi_Destination_node4 : Compute
	{
		// Token: 0x06015B4F RID: 88911 RVA: 0x0068E7A4 File Offset: 0x0068CBA4
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
