using System;

namespace behaviac
{
	// Token: 0x02003B28 RID: 15144
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node35 : Condition
	{
		// Token: 0x06015E09 RID: 89609 RVA: 0x0069C1A4 File Offset: 0x0069A5A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 4;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
