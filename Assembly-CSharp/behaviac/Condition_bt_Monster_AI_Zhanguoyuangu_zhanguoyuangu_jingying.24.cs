using System;

namespace behaviac
{
	// Token: 0x02003F71 RID: 16241
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node10 : Condition
	{
		// Token: 0x06016650 RID: 91728 RVA: 0x006C6310 File Offset: 0x006C4710
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
