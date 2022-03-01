using System;

namespace behaviac
{
	// Token: 0x0200323F RID: 12863
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node11 : Condition
	{
		// Token: 0x06014D01 RID: 85249 RVA: 0x00645364 File Offset: 0x00643764
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
