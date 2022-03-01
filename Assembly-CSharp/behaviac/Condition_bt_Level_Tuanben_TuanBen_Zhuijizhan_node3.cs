using System;

namespace behaviac
{
	// Token: 0x02002B30 RID: 11056
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_node3 : Condition
	{
		// Token: 0x06013F71 RID: 81777 RVA: 0x005FE828 File Offset: 0x005FCC28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = (int)AgentMetaVisitor.GetProperty(pAgent, "CommonIntVar");
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
