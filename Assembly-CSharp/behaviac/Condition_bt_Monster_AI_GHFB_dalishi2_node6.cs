using System;

namespace behaviac
{
	// Token: 0x020032B1 RID: 12977
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dalishi2_node6 : Condition
	{
		// Token: 0x06014DD8 RID: 85464 RVA: 0x00649048 File Offset: 0x00647448
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult != num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
