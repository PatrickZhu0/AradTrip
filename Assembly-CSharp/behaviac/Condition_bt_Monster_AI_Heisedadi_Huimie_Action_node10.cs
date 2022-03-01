using System;

namespace behaviac
{
	// Token: 0x02003411 RID: 13329
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node10 : Condition
	{
		// Token: 0x06015074 RID: 86132 RVA: 0x00655C80 File Offset: 0x00654080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
