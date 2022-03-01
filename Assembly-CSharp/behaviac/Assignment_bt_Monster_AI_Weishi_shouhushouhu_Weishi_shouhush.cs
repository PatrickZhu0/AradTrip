using System;

namespace behaviac
{
	// Token: 0x02003DD2 RID: 15826
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node7 : Assignment
	{
		// Token: 0x06016333 RID: 90931 RVA: 0x006B62D0 File Offset: 0x006B46D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
