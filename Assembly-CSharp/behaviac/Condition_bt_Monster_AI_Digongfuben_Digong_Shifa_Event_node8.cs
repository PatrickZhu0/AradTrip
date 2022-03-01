using System;

namespace behaviac
{
	// Token: 0x0200325F RID: 12895
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node8 : Condition
	{
		// Token: 0x06014D3E RID: 85310 RVA: 0x006462C8 File Offset: 0x006446C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 2;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
