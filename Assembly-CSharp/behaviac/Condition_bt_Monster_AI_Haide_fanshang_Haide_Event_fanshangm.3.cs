using System;

namespace behaviac
{
	// Token: 0x020033C5 RID: 13253
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node5 : Condition
	{
		// Token: 0x06014FE2 RID: 85986 RVA: 0x006534A0 File Offset: 0x006518A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
