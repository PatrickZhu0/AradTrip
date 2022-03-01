using System;

namespace behaviac
{
	// Token: 0x02002AE5 RID: 10981
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node3 : Condition
	{
		// Token: 0x06013EE2 RID: 81634 RVA: 0x005FB6B8 File Offset: 0x005F9AB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = (int)AgentMetaVisitor.GetProperty(pAgent, "CommonIntVar");
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
