using System;

namespace behaviac
{
	// Token: 0x02002AEA RID: 10986
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Lei_node3 : Condition
	{
		// Token: 0x06013EEB RID: 81643 RVA: 0x005FB8C8 File Offset: 0x005F9CC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = (int)AgentMetaVisitor.GetProperty(pAgent, "CommonIntVar");
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
