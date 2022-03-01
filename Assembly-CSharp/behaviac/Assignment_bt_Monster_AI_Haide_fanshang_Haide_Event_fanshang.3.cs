using System;

namespace behaviac
{
	// Token: 0x020033D2 RID: 13266
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node7 : Assignment
	{
		// Token: 0x06014FFB RID: 86011 RVA: 0x00653B44 File Offset: 0x00651F44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
