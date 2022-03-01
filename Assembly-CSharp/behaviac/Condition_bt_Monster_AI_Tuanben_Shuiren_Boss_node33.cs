using System;

namespace behaviac
{
	// Token: 0x02003B20 RID: 15136
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node33 : Condition
	{
		// Token: 0x06015DF9 RID: 89593 RVA: 0x0069BED4 File Offset: 0x0069A2D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 2;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
