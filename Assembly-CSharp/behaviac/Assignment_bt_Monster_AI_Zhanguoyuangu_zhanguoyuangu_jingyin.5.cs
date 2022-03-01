using System;

namespace behaviac
{
	// Token: 0x02003F5F RID: 16223
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node7 : Assignment
	{
		// Token: 0x0601662D RID: 91693 RVA: 0x006C59B4 File Offset: 0x006C3DB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
