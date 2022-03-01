using System;

namespace behaviac
{
	// Token: 0x02003B09 RID: 15113
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node6 : Condition
	{
		// Token: 0x06015DCD RID: 89549 RVA: 0x0069B2AC File Offset: 0x006996AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsSelfInCircle();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
