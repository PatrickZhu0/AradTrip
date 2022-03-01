using System;

namespace behaviac
{
	// Token: 0x02003EF3 RID: 16115
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiamaGHFB_Event_node4 : Condition
	{
		// Token: 0x0601655F RID: 91487 RVA: 0x006C1F14 File Offset: 0x006C0314
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
