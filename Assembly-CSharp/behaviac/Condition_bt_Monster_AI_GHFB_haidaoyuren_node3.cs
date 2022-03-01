using System;

namespace behaviac
{
	// Token: 0x020032C6 RID: 12998
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_haidaoyuren_node3 : Condition
	{
		// Token: 0x06014DFF RID: 85503 RVA: 0x00649EA4 File Offset: 0x006482A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
