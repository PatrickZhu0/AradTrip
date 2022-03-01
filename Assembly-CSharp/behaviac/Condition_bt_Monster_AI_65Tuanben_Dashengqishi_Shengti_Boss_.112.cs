using System;

namespace behaviac
{
	// Token: 0x02002E92 RID: 11922
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node20 : Condition
	{
		// Token: 0x06014600 RID: 83456 RVA: 0x00620B50 File Offset: 0x0061EF50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
