using System;

namespace behaviac
{
	// Token: 0x02003287 RID: 12935
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node7 : Condition
	{
		// Token: 0x06014D8A RID: 85386 RVA: 0x0064783C File Offset: 0x00645C3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
