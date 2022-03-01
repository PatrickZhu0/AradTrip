using System;

namespace behaviac
{
	// Token: 0x02003293 RID: 12947
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node7 : Condition
	{
		// Token: 0x06014DA1 RID: 85409 RVA: 0x00647E60 File Offset: 0x00646260
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
