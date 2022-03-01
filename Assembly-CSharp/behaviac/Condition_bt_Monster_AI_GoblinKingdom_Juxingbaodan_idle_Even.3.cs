using System;

namespace behaviac
{
	// Token: 0x02003380 RID: 13184
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node9 : Condition
	{
		// Token: 0x06014F5E RID: 85854 RVA: 0x006509B8 File Offset: 0x0064EDB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
