using System;

namespace behaviac
{
	// Token: 0x0200325E RID: 12894
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node19 : Assignment
	{
		// Token: 0x06014D3C RID: 85308 RVA: 0x006462A0 File Offset: 0x006446A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
