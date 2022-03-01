using System;

namespace behaviac
{
	// Token: 0x02003F37 RID: 16183
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node10 : Condition
	{
		// Token: 0x060165E0 RID: 91616 RVA: 0x006C4288 File Offset: 0x006C2688
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
