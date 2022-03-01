using System;

namespace behaviac
{
	// Token: 0x02002DD3 RID: 11731
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node73 : Condition
	{
		// Token: 0x06014484 RID: 83076 RVA: 0x006182BC File Offset: 0x006166BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
