using System;

namespace behaviac
{
	// Token: 0x02003A05 RID: 14853
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node14 : Condition
	{
		// Token: 0x06015BD9 RID: 89049 RVA: 0x00690E30 File Offset: 0x0068F230
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 2;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
