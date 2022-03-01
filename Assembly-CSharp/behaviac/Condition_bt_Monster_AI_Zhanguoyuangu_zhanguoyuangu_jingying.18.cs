using System;

namespace behaviac
{
	// Token: 0x02003F62 RID: 16226
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node10 : Condition
	{
		// Token: 0x06016633 RID: 91699 RVA: 0x006C5A9C File Offset: 0x006C3E9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
