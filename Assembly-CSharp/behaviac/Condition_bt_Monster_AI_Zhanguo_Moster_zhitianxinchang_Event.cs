using System;

namespace behaviac
{
	// Token: 0x02003F03 RID: 16131
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Moster_zhitianxinchang_Event_node1 : Condition
	{
		// Token: 0x0601657C RID: 91516 RVA: 0x006C27A0 File Offset: 0x006C0BA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
