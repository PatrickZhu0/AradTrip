using System;

namespace behaviac
{
	// Token: 0x02003B47 RID: 15175
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node66 : Condition
	{
		// Token: 0x06015E44 RID: 89668 RVA: 0x0069D554 File Offset: 0x0069B954
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 2;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
