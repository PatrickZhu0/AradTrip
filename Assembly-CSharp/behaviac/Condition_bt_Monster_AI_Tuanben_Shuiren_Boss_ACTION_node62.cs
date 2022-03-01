using System;

namespace behaviac
{
	// Token: 0x02003B3F RID: 15167
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node62 : Condition
	{
		// Token: 0x06015E34 RID: 89652 RVA: 0x0069D37C File Offset: 0x0069B77C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
