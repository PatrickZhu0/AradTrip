using System;

namespace behaviac
{
	// Token: 0x02002DD1 RID: 11729
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node70 : Assignment
	{
		// Token: 0x06014480 RID: 83072 RVA: 0x00618258 File Offset: 0x00616658
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
