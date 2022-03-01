using System;

namespace behaviac
{
	// Token: 0x02003F44 RID: 16196
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node10 : Condition
	{
		// Token: 0x060165F9 RID: 91641 RVA: 0x006C49B4 File Offset: 0x006C2DB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
