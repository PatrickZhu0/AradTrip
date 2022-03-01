using System;

namespace behaviac
{
	// Token: 0x02003296 RID: 12950
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node10 : Assignment
	{
		// Token: 0x06014DA7 RID: 85415 RVA: 0x00647F28 File Offset: 0x00646328
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
