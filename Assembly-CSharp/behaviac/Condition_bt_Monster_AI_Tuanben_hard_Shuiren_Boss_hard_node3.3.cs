using System;

namespace behaviac
{
	// Token: 0x02003D78 RID: 15736
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node33 : Condition
	{
		// Token: 0x06016286 RID: 90758 RVA: 0x006B2BE4 File Offset: 0x006B0FE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 2;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
