using System;

namespace behaviac
{
	// Token: 0x02003298 RID: 12952
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Xianjing_Event_node4 : Condition
	{
		// Token: 0x06014DAA RID: 85418 RVA: 0x00648300 File Offset: 0x00646700
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
