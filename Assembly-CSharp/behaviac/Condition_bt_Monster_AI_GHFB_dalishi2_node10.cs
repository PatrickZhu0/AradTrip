using System;

namespace behaviac
{
	// Token: 0x020032AF RID: 12975
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_dalishi2_node10 : Condition
	{
		// Token: 0x06014DD4 RID: 85460 RVA: 0x00648FB8 File Offset: 0x006473B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 1;
			bool flag = lastResult == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
