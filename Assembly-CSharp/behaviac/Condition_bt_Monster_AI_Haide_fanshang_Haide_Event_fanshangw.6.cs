using System;

namespace behaviac
{
	// Token: 0x020033E0 RID: 13280
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node10 : Condition
	{
		// Token: 0x06015016 RID: 86038 RVA: 0x00654234 File Offset: 0x00652634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
