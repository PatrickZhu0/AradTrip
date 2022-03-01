using System;

namespace behaviac
{
	// Token: 0x020032A7 RID: 12967
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dalishi1_node10 : Condition
	{
		// Token: 0x06014DC5 RID: 85445 RVA: 0x00648A84 File Offset: 0x00646E84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
