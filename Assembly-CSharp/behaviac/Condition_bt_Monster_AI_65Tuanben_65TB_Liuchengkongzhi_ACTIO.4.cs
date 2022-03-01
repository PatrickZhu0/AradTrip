using System;

namespace behaviac
{
	// Token: 0x02002BBE RID: 11198
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node4 : Condition
	{
		// Token: 0x06014081 RID: 82049 RVA: 0x006042E0 File Offset: 0x006026E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
