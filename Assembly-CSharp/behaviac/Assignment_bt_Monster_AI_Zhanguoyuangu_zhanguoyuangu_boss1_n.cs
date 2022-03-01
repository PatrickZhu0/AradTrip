using System;

namespace behaviac
{
	// Token: 0x02003F0D RID: 16141
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node7 : Assignment
	{
		// Token: 0x0601658F RID: 91535 RVA: 0x006C2C1C File Offset: 0x006C101C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int shouhufanshang = 1;
			((BTAgent)pAgent).shouhufanshang = shouhufanshang;
			return result;
		}
	}
}
