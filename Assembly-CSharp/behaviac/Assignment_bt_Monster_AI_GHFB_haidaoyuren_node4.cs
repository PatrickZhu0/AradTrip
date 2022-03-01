using System;

namespace behaviac
{
	// Token: 0x020032C9 RID: 13001
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_GHFB_haidaoyuren_node4 : Assignment
	{
		// Token: 0x06014E05 RID: 85509 RVA: 0x00649FCC File Offset: 0x006483CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
