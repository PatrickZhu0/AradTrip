using System;

namespace behaviac
{
	// Token: 0x02002B0E RID: 11022
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node38 : Condition
	{
		// Token: 0x06013F2F RID: 81711 RVA: 0x005FD394 File Offset: 0x005FB794
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = (int)AgentMetaVisitor.GetProperty(pAgent, "CommonIntVar");
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
