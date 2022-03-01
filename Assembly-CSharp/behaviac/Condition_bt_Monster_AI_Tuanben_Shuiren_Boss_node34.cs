using System;

namespace behaviac
{
	// Token: 0x02003B24 RID: 15140
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node34 : Condition
	{
		// Token: 0x06015E01 RID: 89601 RVA: 0x0069C03C File Offset: 0x0069A43C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 3;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
