using System;

namespace behaviac
{
	// Token: 0x020032B3 RID: 12979
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dalishi2_node8 : Condition
	{
		// Token: 0x06014DDC RID: 85468 RVA: 0x00649128 File Offset: 0x00647528
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
