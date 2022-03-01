using System;

namespace behaviac
{
	// Token: 0x02003F10 RID: 16144
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node10 : Condition
	{
		// Token: 0x06016595 RID: 91541 RVA: 0x006C2D04 File Offset: 0x006C1104
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
