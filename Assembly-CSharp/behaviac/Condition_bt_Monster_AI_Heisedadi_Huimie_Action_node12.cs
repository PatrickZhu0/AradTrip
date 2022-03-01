using System;

namespace behaviac
{
	// Token: 0x02003416 RID: 13334
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node12 : Condition
	{
		// Token: 0x0601507E RID: 86142 RVA: 0x00655E6C File Offset: 0x0065426C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
