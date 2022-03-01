using System;

namespace behaviac
{
	// Token: 0x02003280 RID: 12928
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node11 : Condition
	{
		// Token: 0x06014D7C RID: 85372 RVA: 0x006476B8 File Offset: 0x00645AB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
