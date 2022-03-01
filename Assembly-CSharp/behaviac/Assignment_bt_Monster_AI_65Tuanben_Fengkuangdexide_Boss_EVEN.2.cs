using System;

namespace behaviac
{
	// Token: 0x02002F00 RID: 12032
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node16 : Assignment
	{
		// Token: 0x060146D9 RID: 83673 RVA: 0x00624EA0 File Offset: 0x006232A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
