using System;

namespace behaviac
{
	// Token: 0x020033D0 RID: 13264
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node5 : Condition
	{
		// Token: 0x06014FF7 RID: 86007 RVA: 0x00653AA8 File Offset: 0x00651EA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
