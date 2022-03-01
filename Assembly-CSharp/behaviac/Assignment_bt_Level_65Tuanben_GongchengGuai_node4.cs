using System;

namespace behaviac
{
	// Token: 0x02002AD9 RID: 10969
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Level_65Tuanben_GongchengGuai_node4 : Assignment
	{
		// Token: 0x06013ECC RID: 81612 RVA: 0x005FAFDC File Offset: 0x005F93DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1;
			pAgent.SetVariable<int>("CommonIntVar", 253469147U, value);
			return result;
		}
	}
}
