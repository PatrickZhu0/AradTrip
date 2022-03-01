using System;

namespace behaviac
{
	// Token: 0x020039FD RID: 14845
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node8 : Condition
	{
		// Token: 0x06015BC9 RID: 89033 RVA: 0x00690C70 File Offset: 0x0068F070
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
