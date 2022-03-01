using System;

namespace behaviac
{
	// Token: 0x02003F0B RID: 16139
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node5 : Condition
	{
		// Token: 0x0601658B RID: 91531 RVA: 0x006C2B80 File Offset: 0x006C0F80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
