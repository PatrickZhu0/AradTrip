using System;

namespace behaviac
{
	// Token: 0x020032C1 RID: 12993
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dapao2_node6 : Condition
	{
		// Token: 0x06014DF6 RID: 85494 RVA: 0x00649AA8 File Offset: 0x00647EA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult != num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
