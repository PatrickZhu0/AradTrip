using System;

namespace behaviac
{
	// Token: 0x02002EB5 RID: 11957
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node38 : Assignment
	{
		// Token: 0x06014645 RID: 83525 RVA: 0x0062207C File Offset: 0x0062047C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
