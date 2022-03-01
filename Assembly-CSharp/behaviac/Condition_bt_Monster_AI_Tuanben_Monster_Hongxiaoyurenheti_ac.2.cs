using System;

namespace behaviac
{
	// Token: 0x02003AF7 RID: 15095
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node6 : Condition
	{
		// Token: 0x06015DAB RID: 89515 RVA: 0x0069A8A0 File Offset: 0x00698CA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsSelfInCircle();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
