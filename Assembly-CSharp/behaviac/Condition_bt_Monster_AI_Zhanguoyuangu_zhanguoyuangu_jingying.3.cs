using System;

namespace behaviac
{
	// Token: 0x02003F3F RID: 16191
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node5 : Condition
	{
		// Token: 0x060165EF RID: 91631 RVA: 0x006C4830 File Offset: 0x006C2C30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
