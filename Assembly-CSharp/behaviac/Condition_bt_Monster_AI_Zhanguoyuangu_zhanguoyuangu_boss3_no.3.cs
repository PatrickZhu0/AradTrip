using System;

namespace behaviac
{
	// Token: 0x02003F25 RID: 16165
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node5 : Condition
	{
		// Token: 0x060165BD RID: 91581 RVA: 0x006C39D8 File Offset: 0x006C1DD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
