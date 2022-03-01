using System;

namespace behaviac
{
	// Token: 0x02003F50 RID: 16208
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node7 : Assignment
	{
		// Token: 0x06016610 RID: 91664 RVA: 0x006C5140 File Offset: 0x006C3540
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
