using System;

namespace behaviac
{
	// Token: 0x02003D90 RID: 15760
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node25 : Condition
	{
		// Token: 0x060162B6 RID: 90806 RVA: 0x006B3454 File Offset: 0x006B1854
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 8;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
