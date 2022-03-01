using System;

namespace behaviac
{
	// Token: 0x020033DD RID: 13277
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node7 : Assignment
	{
		// Token: 0x06015010 RID: 86032 RVA: 0x0065414C File Offset: 0x0065254C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
