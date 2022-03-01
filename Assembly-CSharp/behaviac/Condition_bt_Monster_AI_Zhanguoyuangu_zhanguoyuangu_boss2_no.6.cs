using System;

namespace behaviac
{
	// Token: 0x02003F1D RID: 16157
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node10 : Condition
	{
		// Token: 0x060165AE RID: 91566 RVA: 0x006C3430 File Offset: 0x006C1830
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
