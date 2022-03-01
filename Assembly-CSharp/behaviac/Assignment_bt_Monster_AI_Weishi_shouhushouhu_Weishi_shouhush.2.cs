using System;

namespace behaviac
{
	// Token: 0x02003DD7 RID: 15831
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node12 : Assignment
	{
		// Token: 0x0601633D RID: 90941 RVA: 0x006B6454 File Offset: 0x006B4854
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 0;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
