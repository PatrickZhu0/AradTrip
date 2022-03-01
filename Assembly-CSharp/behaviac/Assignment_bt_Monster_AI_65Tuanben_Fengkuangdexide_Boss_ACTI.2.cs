using System;

namespace behaviac
{
	// Token: 0x02002EBC RID: 11964
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node39 : Assignment
	{
		// Token: 0x06014653 RID: 83539 RVA: 0x006222F0 File Offset: 0x006206F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
