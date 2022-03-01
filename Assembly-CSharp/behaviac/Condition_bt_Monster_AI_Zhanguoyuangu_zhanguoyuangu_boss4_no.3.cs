using System;

namespace behaviac
{
	// Token: 0x02003F32 RID: 16178
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node5 : Condition
	{
		// Token: 0x060165D6 RID: 91606 RVA: 0x006C4104 File Offset: 0x006C2504
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
