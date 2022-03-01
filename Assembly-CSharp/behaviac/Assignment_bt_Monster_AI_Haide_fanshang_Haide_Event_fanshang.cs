using System;

namespace behaviac
{
	// Token: 0x020033C7 RID: 13255
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node7 : Assignment
	{
		// Token: 0x06014FE6 RID: 85990 RVA: 0x0065353C File Offset: 0x0065193C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
