using System;

namespace behaviac
{
	// Token: 0x02003253 RID: 12883
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node1 : Condition
	{
		// Token: 0x06014D26 RID: 85286 RVA: 0x00645FC4 File Offset: 0x006443C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
