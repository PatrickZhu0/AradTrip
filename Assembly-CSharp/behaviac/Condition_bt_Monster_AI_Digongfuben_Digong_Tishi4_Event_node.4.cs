using System;

namespace behaviac
{
	// Token: 0x02003290 RID: 12944
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node15 : Condition
	{
		// Token: 0x06014D9B RID: 85403 RVA: 0x00647DB8 File Offset: 0x006461B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
