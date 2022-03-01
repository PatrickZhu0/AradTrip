using System;

namespace behaviac
{
	// Token: 0x02003F07 RID: 16135
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguo_Moster_zhitianxinchang_Event_node5 : Assignment
	{
		// Token: 0x06016584 RID: 91524 RVA: 0x006C292C File Offset: 0x006C0D2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
