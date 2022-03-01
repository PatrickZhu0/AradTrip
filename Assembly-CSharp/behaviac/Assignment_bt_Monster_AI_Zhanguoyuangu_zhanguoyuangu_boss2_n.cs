using System;

namespace behaviac
{
	// Token: 0x02003F1A RID: 16154
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node7 : Assignment
	{
		// Token: 0x060165A8 RID: 91560 RVA: 0x006C3348 File Offset: 0x006C1748
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
