using System;

namespace behaviac
{
	// Token: 0x02003F27 RID: 16167
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node7 : Assignment
	{
		// Token: 0x060165C1 RID: 91585 RVA: 0x006C3A74 File Offset: 0x006C1E74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
