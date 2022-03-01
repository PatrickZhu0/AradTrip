using System;

namespace behaviac
{
	// Token: 0x02003B30 RID: 15152
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node38 : Condition
	{
		// Token: 0x06015E19 RID: 89625 RVA: 0x0069C474 File Offset: 0x0069A874
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 6;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
