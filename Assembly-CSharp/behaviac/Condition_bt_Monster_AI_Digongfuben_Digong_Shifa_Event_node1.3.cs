using System;

namespace behaviac
{
	// Token: 0x0200325C RID: 12892
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node18 : Condition
	{
		// Token: 0x06014D38 RID: 85304 RVA: 0x0064621C File Offset: 0x0064461C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
