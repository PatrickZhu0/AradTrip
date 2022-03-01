using System;

namespace behaviac
{
	// Token: 0x02003B34 RID: 15156
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node37 : Condition
	{
		// Token: 0x06015E21 RID: 89633 RVA: 0x0069C5DC File Offset: 0x0069A9DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 7;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
