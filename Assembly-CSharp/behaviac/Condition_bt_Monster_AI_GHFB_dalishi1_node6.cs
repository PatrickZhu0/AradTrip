using System;

namespace behaviac
{
	// Token: 0x020032A9 RID: 12969
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dalishi1_node6 : Condition
	{
		// Token: 0x06014DC9 RID: 85449 RVA: 0x00648B14 File Offset: 0x00646F14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult != num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
