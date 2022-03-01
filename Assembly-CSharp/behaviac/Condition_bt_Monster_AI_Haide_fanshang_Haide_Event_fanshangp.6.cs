using System;

namespace behaviac
{
	// Token: 0x020033D5 RID: 13269
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node10 : Condition
	{
		// Token: 0x06015001 RID: 86017 RVA: 0x00653C2C File Offset: 0x0065202C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
