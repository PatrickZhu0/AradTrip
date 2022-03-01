using System;

namespace behaviac
{
	// Token: 0x0200341C RID: 13340
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node8 : Condition
	{
		// Token: 0x06015088 RID: 86152 RVA: 0x00656668 File Offset: 0x00654A68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
