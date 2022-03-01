using System;

namespace behaviac
{
	// Token: 0x020033BE RID: 13246
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GWGC_GWGC_qishiyuanjun_node1 : Condition
	{
		// Token: 0x06014FD5 RID: 85973 RVA: 0x0065315C File Offset: 0x0065155C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
