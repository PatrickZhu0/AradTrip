using System;

namespace behaviac
{
	// Token: 0x02003266 RID: 12902
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tanzhaodeng_Event_node5 : Assignment
	{
		// Token: 0x06014D4B RID: 85323 RVA: 0x0064694C File Offset: 0x00644D4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
