using System;

namespace behaviac
{
	// Token: 0x02002D8C RID: 11660
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node24 : Condition
	{
		// Token: 0x060143FA RID: 82938 RVA: 0x006156F8 File Offset: 0x00613AF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
