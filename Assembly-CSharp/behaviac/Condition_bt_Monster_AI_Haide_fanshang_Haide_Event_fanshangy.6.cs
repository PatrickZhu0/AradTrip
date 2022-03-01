using System;

namespace behaviac
{
	// Token: 0x020033EB RID: 13291
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node10 : Condition
	{
		// Token: 0x0601502B RID: 86059 RVA: 0x0065483C File Offset: 0x00652C3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
