using System;

namespace behaviac
{
	// Token: 0x02003DF3 RID: 15859
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node7 : Assignment
	{
		// Token: 0x06016372 RID: 90994 RVA: 0x006B74E8 File Offset: 0x006B58E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
