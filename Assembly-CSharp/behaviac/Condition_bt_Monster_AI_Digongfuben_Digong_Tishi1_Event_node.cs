using System;

namespace behaviac
{
	// Token: 0x02003268 RID: 12904
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node11 : Condition
	{
		// Token: 0x06014D4E RID: 85326 RVA: 0x00646A70 File Offset: 0x00644E70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
