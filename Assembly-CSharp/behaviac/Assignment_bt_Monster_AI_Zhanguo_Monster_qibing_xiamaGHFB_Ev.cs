using System;

namespace behaviac
{
	// Token: 0x02003EF7 RID: 16119
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguo_Monster_qibing_xiamaGHFB_Event_node5 : Assignment
	{
		// Token: 0x06016567 RID: 91495 RVA: 0x006C20A0 File Offset: 0x006C04A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
