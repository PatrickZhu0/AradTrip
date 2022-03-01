using System;

namespace behaviac
{
	// Token: 0x020032BF RID: 12991
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dapao2_node10 : Condition
	{
		// Token: 0x06014DF2 RID: 85490 RVA: 0x00649A18 File Offset: 0x00647E18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
