using System;

namespace behaviac
{
	// Token: 0x02003D84 RID: 15748
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node36 : Condition
	{
		// Token: 0x0601629E RID: 90782 RVA: 0x006B301C File Offset: 0x006B141C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 5;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
