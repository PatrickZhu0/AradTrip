using System;

namespace behaviac
{
	// Token: 0x02003D74 RID: 15732
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node32 : Condition
	{
		// Token: 0x0601627E RID: 90750 RVA: 0x006B2A7C File Offset: 0x006B0E7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
