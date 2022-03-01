using System;

namespace behaviac
{
	// Token: 0x02002D87 RID: 11655
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node131 : Condition
	{
		// Token: 0x060143F0 RID: 82928 RVA: 0x00615544 File Offset: 0x00613944
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
