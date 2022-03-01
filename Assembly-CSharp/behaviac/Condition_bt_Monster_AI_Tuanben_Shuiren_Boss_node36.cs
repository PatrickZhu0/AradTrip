using System;

namespace behaviac
{
	// Token: 0x02003B2C RID: 15148
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node36 : Condition
	{
		// Token: 0x06015E11 RID: 89617 RVA: 0x0069C30C File Offset: 0x0069A70C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 5;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
