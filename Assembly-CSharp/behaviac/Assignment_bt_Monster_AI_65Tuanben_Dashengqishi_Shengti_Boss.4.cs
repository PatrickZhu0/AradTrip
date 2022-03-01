using System;

namespace behaviac
{
	// Token: 0x02002E08 RID: 11784
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node105 : Assignment
	{
		// Token: 0x060144EE RID: 83182 RVA: 0x00619798 File Offset: 0x00617B98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
