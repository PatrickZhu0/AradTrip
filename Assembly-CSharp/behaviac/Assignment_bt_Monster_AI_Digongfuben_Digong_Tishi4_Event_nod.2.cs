using System;

namespace behaviac
{
	// Token: 0x02003292 RID: 12946
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node5 : Assignment
	{
		// Token: 0x06014D9F RID: 85407 RVA: 0x00647E38 File Offset: 0x00646238
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
