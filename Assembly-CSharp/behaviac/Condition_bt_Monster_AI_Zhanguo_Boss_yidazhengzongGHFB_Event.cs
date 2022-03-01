using System;

namespace behaviac
{
	// Token: 0x02003E71 RID: 15985
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzongGHFB_Event_node3 : Condition
	{
		// Token: 0x06016465 RID: 91237 RVA: 0x006BC3CC File Offset: 0x006BA7CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
