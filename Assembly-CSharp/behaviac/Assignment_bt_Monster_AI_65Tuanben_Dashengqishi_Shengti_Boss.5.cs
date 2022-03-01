using System;

namespace behaviac
{
	// Token: 0x02002E33 RID: 11827
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node113 : Assignment
	{
		// Token: 0x06014544 RID: 83268 RVA: 0x0061A8DC File Offset: 0x00618CDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
