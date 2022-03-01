using System;

namespace behaviac
{
	// Token: 0x020032BB RID: 12987
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dapao1_node8 : Condition
	{
		// Token: 0x06014DEB RID: 85483 RVA: 0x00649650 File Offset: 0x00647A50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
