using System;

namespace behaviac
{
	// Token: 0x02002AED RID: 10989
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Level_Tuanben_TuanBen_Lei_node4 : Assignment
	{
		// Token: 0x06013EF1 RID: 81649 RVA: 0x005FB978 File Offset: 0x005F9D78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1;
			pAgent.SetVariable<int>("CommonIntVar", 253469147U, value);
			return result;
		}
	}
}
