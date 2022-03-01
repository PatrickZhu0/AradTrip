using System;

namespace behaviac
{
	// Token: 0x020032C3 RID: 12995
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dapao2_node8 : Condition
	{
		// Token: 0x06014DFA RID: 85498 RVA: 0x00649B88 File Offset: 0x00647F88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
