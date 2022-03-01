using System;

namespace behaviac
{
	// Token: 0x020032B7 RID: 12983
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dapao1_node10 : Condition
	{
		// Token: 0x06014DE3 RID: 85475 RVA: 0x006494EC File Offset: 0x006478EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
