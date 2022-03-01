using System;

namespace behaviac
{
	// Token: 0x02003F41 RID: 16193
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node7 : Assignment
	{
		// Token: 0x060165F3 RID: 91635 RVA: 0x006C48CC File Offset: 0x006C2CCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
