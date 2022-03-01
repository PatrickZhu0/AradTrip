using System;

namespace behaviac
{
	// Token: 0x02003F6E RID: 16238
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node7 : Assignment
	{
		// Token: 0x0601664A RID: 91722 RVA: 0x006C6228 File Offset: 0x006C4628
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
