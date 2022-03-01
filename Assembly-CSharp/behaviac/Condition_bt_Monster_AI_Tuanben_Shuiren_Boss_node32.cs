using System;

namespace behaviac
{
	// Token: 0x02003B1C RID: 15132
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node32 : Condition
	{
		// Token: 0x06015DF1 RID: 89585 RVA: 0x0069BD6C File Offset: 0x0069A16C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
