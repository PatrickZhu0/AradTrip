using System;

namespace behaviac
{
	// Token: 0x02003B07 RID: 15111
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node7 : Assignment
	{
		// Token: 0x06015DC9 RID: 89545 RVA: 0x0069B250 File Offset: 0x00699650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1000;
			pAgent.SetVariable<int>("radius", 1327198659U, value);
			return result;
		}
	}
}
