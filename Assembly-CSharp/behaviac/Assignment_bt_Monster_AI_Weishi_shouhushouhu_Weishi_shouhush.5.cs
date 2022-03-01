using System;

namespace behaviac
{
	// Token: 0x02003DE8 RID: 15848
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node7 : Assignment
	{
		// Token: 0x0601635D RID: 90973 RVA: 0x006B6EE0 File Offset: 0x006B52E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
