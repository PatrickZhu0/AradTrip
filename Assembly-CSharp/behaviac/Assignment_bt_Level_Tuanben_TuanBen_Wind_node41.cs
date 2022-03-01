using System;

namespace behaviac
{
	// Token: 0x02002AF3 RID: 10995
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Level_Tuanben_TuanBen_Wind_node41 : Assignment
	{
		// Token: 0x06013EFB RID: 81659 RVA: 0x005FC19C File Offset: 0x005FA59C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1;
			pAgent.SetVariable<int>("CommonIntVar", 253469147U, value);
			return result;
		}
	}
}
