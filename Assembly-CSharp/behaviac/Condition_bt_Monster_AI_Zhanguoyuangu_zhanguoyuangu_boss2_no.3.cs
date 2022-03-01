using System;

namespace behaviac
{
	// Token: 0x02003F18 RID: 16152
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node5 : Condition
	{
		// Token: 0x060165A4 RID: 91556 RVA: 0x006C32AC File Offset: 0x006C16AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
