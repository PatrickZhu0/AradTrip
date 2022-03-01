using System;

namespace behaviac
{
	// Token: 0x02002B35 RID: 11061
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node3 : Condition
	{
		// Token: 0x06013F7A RID: 81786 RVA: 0x005FEA3C File Offset: 0x005FCE3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = (int)AgentMetaVisitor.GetProperty(pAgent, "CommonIntVar");
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
