using System;

namespace behaviac
{
	// Token: 0x02002E84 RID: 11908
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node9 : Condition
	{
		// Token: 0x060145E4 RID: 83428 RVA: 0x006207C0 File Offset: 0x0061EBC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
