using System;

namespace behaviac
{
	// Token: 0x02003B4A RID: 15178
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node67 : Assignment
	{
		// Token: 0x06015E4A RID: 89674 RVA: 0x0069D618 File Offset: 0x0069BA18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
