using System;

namespace behaviac
{
	// Token: 0x020032B8 RID: 12984
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dapao1_node6 : Condition
	{
		// Token: 0x06014DE5 RID: 85477 RVA: 0x00649524 File Offset: 0x00647924
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult != num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
