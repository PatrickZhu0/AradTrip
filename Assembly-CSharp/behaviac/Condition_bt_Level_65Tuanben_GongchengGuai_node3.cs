using System;

namespace behaviac
{
	// Token: 0x02002AD7 RID: 10967
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_65Tuanben_GongchengGuai_node3 : Condition
	{
		// Token: 0x06013EC8 RID: 81608 RVA: 0x005FADB4 File Offset: 0x005F91B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = (int)AgentMetaVisitor.GetProperty(pAgent, "CommonIntVar");
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
