using System;

namespace behaviac
{
	// Token: 0x02003F2A RID: 16170
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node10 : Condition
	{
		// Token: 0x060165C7 RID: 91591 RVA: 0x006C3B5C File Offset: 0x006C1F5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 1;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
