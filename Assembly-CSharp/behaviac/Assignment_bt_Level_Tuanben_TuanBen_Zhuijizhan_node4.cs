using System;

namespace behaviac
{
	// Token: 0x02002B33 RID: 11059
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Level_Tuanben_TuanBen_Zhuijizhan_node4 : Assignment
	{
		// Token: 0x06013F77 RID: 81783 RVA: 0x005FE8DC File Offset: 0x005FCCDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1;
			pAgent.SetVariable<int>("CommonIntVar", 253469147U, value);
			return result;
		}
	}
}
