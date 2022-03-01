using System;

namespace behaviac
{
	// Token: 0x02002B38 RID: 11064
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node4 : Assignment
	{
		// Token: 0x06013F80 RID: 81792 RVA: 0x005FEAF0 File Offset: 0x005FCEF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1;
			pAgent.SetVariable<int>("CommonIntVar", 253469147U, value);
			return result;
		}
	}
}
