using System;

namespace behaviac
{
	// Token: 0x02003F53 RID: 16211
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node10 : Condition
	{
		// Token: 0x06016616 RID: 91670 RVA: 0x006C5228 File Offset: 0x006C3628
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
