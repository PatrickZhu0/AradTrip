using System;

namespace behaviac
{
	// Token: 0x02002B11 RID: 11025
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Level_Tuanben_TuanBen_Wind_hard_node41 : Assignment
	{
		// Token: 0x06013F35 RID: 81717 RVA: 0x005FD444 File Offset: 0x005FB844
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1;
			pAgent.SetVariable<int>("CommonIntVar", 253469147U, value);
			return result;
		}
	}
}
