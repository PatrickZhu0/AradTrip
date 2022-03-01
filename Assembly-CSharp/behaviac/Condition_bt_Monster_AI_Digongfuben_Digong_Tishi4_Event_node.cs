using System;

namespace behaviac
{
	// Token: 0x0200328C RID: 12940
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node11 : Condition
	{
		// Token: 0x06014D93 RID: 85395 RVA: 0x00647CDC File Offset: 0x006460DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
