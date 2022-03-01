using System;

namespace behaviac
{
	// Token: 0x02003D16 RID: 15638
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node6 : Condition
	{
		// Token: 0x060161C9 RID: 90569 RVA: 0x006AF3C0 File Offset: 0x006AD7C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsSelfInCircle();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
