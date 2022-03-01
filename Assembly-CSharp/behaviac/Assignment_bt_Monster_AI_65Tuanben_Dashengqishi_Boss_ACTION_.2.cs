using System;

namespace behaviac
{
	// Token: 0x02002D90 RID: 11664
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node33 : Assignment
	{
		// Token: 0x06014402 RID: 82946 RVA: 0x00615884 File Offset: 0x00613C84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
