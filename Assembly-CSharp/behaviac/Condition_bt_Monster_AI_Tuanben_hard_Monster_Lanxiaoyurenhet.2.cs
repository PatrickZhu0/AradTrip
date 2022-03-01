using System;

namespace behaviac
{
	// Token: 0x02003D28 RID: 15656
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node6 : Condition
	{
		// Token: 0x060161EB RID: 90603 RVA: 0x006AFDCC File Offset: 0x006AE1CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsSelfInCircle();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
