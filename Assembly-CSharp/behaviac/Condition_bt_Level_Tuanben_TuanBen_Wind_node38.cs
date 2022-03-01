using System;

namespace behaviac
{
	// Token: 0x02002AF0 RID: 10992
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node38 : Condition
	{
		// Token: 0x06013EF5 RID: 81653 RVA: 0x005FC0EC File Offset: 0x005FA4EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = (int)AgentMetaVisitor.GetProperty(pAgent, "CommonIntVar");
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
