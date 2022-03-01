using System;

namespace behaviac
{
	// Token: 0x020032AB RID: 12971
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dalishi1_node8 : Condition
	{
		// Token: 0x06014DCD RID: 85453 RVA: 0x00648BF4 File Offset: 0x00646FF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
