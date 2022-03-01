using System;

namespace behaviac
{
	// Token: 0x02003264 RID: 12900
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tanzhaodeng_Event_node4 : Condition
	{
		// Token: 0x06014D47 RID: 85319 RVA: 0x006468C8 File Offset: 0x00644CC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
