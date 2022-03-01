using System;

namespace behaviac
{
	// Token: 0x02003EF9 RID: 16121
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama_Event_node4 : Condition
	{
		// Token: 0x0601656A RID: 91498 RVA: 0x006C2230 File Offset: 0x006C0630
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
