using System;

namespace behaviac
{
	// Token: 0x0200326F RID: 12911
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node7 : Condition
	{
		// Token: 0x06014D5C RID: 85340 RVA: 0x00646BF4 File Offset: 0x00644FF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
