using System;

namespace behaviac
{
	// Token: 0x020033DB RID: 13275
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node5 : Condition
	{
		// Token: 0x0601500C RID: 86028 RVA: 0x006540B0 File Offset: 0x006524B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
