using System;

namespace behaviac
{
	// Token: 0x020033C1 RID: 13249
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_GWGC_GWGC_qishiyuanjun_node4 : Assignment
	{
		// Token: 0x06014FDB RID: 85979 RVA: 0x00653284 File Offset: 0x00651684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
