using System;

namespace behaviac
{
	// Token: 0x02003D70 RID: 15728
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node30 : Condition
	{
		// Token: 0x06016276 RID: 90742 RVA: 0x006B2914 File Offset: 0x006B0D14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
