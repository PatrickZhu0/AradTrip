using System;

namespace behaviac
{
	// Token: 0x020035E3 RID: 13795
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node7 : Condition
	{
		// Token: 0x060153EF RID: 87023 RVA: 0x00667894 File Offset: 0x00665C94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = (int)AgentMetaVisitor.GetProperty(pAgent, "zhaohuancishu");
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
