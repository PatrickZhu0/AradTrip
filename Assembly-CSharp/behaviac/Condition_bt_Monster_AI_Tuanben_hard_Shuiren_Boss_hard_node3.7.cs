using System;

namespace behaviac
{
	// Token: 0x02003D88 RID: 15752
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node38 : Condition
	{
		// Token: 0x060162A6 RID: 90790 RVA: 0x006B3184 File Offset: 0x006B1584
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 6;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
