using System;

namespace behaviac
{
	// Token: 0x02003AC6 RID: 15046
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node3 : Condition
	{
		// Token: 0x06015D4C RID: 89420 RVA: 0x00698774 File Offset: 0x00696B74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
