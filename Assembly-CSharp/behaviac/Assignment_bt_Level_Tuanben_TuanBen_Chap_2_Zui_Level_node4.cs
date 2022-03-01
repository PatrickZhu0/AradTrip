using System;

namespace behaviac
{
	// Token: 0x02002AE8 RID: 10984
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node4 : Assignment
	{
		// Token: 0x06013EE8 RID: 81640 RVA: 0x005FB768 File Offset: 0x005F9B68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1;
			pAgent.SetVariable<int>("CommonIntVar", 253469147U, value);
			return result;
		}
	}
}
