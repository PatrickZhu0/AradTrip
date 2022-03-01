using System;

namespace behaviac
{
	// Token: 0x02003175 RID: 12661
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node3 : Condition
	{
		// Token: 0x06014B82 RID: 84866 RVA: 0x0063D3A8 File Offset: 0x0063B7A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
