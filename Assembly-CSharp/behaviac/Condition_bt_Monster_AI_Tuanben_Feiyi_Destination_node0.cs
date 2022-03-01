using System;

namespace behaviac
{
	// Token: 0x020039BC RID: 14780
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi_Destination_node0 : Condition
	{
		// Token: 0x06015B4B RID: 88907 RVA: 0x0068E740 File Offset: 0x0068CB40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 10;
			bool flag = bianshen <= num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
