using System;

namespace behaviac
{
	// Token: 0x02003D80 RID: 15744
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node35 : Condition
	{
		// Token: 0x06016296 RID: 90774 RVA: 0x006B2EB4 File Offset: 0x006B12B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 4;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
