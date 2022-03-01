using System;

namespace behaviac
{
	// Token: 0x02003284 RID: 12932
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node15 : Condition
	{
		// Token: 0x06014D84 RID: 85380 RVA: 0x00647794 File Offset: 0x00645B94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
