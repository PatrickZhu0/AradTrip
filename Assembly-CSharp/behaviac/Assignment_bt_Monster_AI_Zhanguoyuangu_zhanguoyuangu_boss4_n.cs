using System;

namespace behaviac
{
	// Token: 0x02003F34 RID: 16180
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node7 : Assignment
	{
		// Token: 0x060165DA RID: 91610 RVA: 0x006C41A0 File Offset: 0x006C25A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
