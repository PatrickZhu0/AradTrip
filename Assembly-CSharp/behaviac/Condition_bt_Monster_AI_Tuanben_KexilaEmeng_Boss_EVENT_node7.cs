using System;

namespace behaviac
{
	// Token: 0x02003A01 RID: 14849
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node7 : Condition
	{
		// Token: 0x06015BD1 RID: 89041 RVA: 0x00690D50 File Offset: 0x0068F150
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
