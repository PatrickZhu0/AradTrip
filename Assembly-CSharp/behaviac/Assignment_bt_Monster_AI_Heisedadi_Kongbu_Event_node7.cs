using System;

namespace behaviac
{
	// Token: 0x020034B4 RID: 13492
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Heisedadi_Kongbu_Event_node7 : Assignment
	{
		// Token: 0x060151AF RID: 86447 RVA: 0x0065C108 File Offset: 0x0065A508
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
