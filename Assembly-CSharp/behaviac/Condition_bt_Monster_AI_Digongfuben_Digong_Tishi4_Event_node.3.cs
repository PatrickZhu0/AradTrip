using System;

namespace behaviac
{
	// Token: 0x0200328F RID: 12943
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node4 : Condition
	{
		// Token: 0x06014D99 RID: 85401 RVA: 0x00647D80 File Offset: 0x00646180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 3;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
