using System;

namespace behaviac
{
	// Token: 0x020033E8 RID: 13288
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node7 : Assignment
	{
		// Token: 0x06015025 RID: 86053 RVA: 0x00654754 File Offset: 0x00652B54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
