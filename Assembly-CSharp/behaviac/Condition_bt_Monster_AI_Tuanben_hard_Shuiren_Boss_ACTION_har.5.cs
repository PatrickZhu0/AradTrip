using System;

namespace behaviac
{
	// Token: 0x02003D41 RID: 15681
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node66 : Condition
	{
		// Token: 0x06016219 RID: 90649 RVA: 0x006B0944 File Offset: 0x006AED44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 2;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
