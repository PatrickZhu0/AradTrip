using System;

namespace behaviac
{
	// Token: 0x02003F4E RID: 16206
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node5 : Condition
	{
		// Token: 0x0601660C RID: 91660 RVA: 0x006C50A4 File Offset: 0x006C34A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
