using System;

namespace behaviac
{
	// Token: 0x02003DDD RID: 15837
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangputong_node7 : Assignment
	{
		// Token: 0x06016348 RID: 90952 RVA: 0x006B68D8 File Offset: 0x006B4CD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
