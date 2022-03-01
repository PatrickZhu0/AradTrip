using System;

namespace behaviac
{
	// Token: 0x020037EC RID: 14316
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node4 : Condition
	{
		// Token: 0x060157CF RID: 88015 RVA: 0x0067C5DC File Offset: 0x0067A9DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
