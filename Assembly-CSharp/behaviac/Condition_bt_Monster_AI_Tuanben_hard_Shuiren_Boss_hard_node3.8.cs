using System;

namespace behaviac
{
	// Token: 0x02003D8C RID: 15756
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node37 : Condition
	{
		// Token: 0x060162AE RID: 90798 RVA: 0x006B32EC File Offset: 0x006B16EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 7;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
