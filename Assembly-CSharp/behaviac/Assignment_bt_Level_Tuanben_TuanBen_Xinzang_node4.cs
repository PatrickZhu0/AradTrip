using System;

namespace behaviac
{
	// Token: 0x02002B2E RID: 11054
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Level_Tuanben_TuanBen_Xinzang_node4 : Assignment
	{
		// Token: 0x06013F6E RID: 81774 RVA: 0x005FE6C8 File Offset: 0x005FCAC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1;
			pAgent.SetVariable<int>("CommonIntVar", 253469147U, value);
			return result;
		}
	}
}
