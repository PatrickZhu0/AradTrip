using System;

namespace behaviac
{
	// Token: 0x020033E6 RID: 13286
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node5 : Condition
	{
		// Token: 0x06015021 RID: 86049 RVA: 0x006546B8 File Offset: 0x00652AB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
