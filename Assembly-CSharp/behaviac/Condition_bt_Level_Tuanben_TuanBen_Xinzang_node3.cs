using System;

namespace behaviac
{
	// Token: 0x02002B2B RID: 11051
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Xinzang_node3 : Condition
	{
		// Token: 0x06013F68 RID: 81768 RVA: 0x005FE618 File Offset: 0x005FCA18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = (int)AgentMetaVisitor.GetProperty(pAgent, "CommonIntVar");
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
