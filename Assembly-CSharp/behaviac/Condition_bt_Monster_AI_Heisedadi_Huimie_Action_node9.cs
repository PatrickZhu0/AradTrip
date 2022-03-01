using System;

namespace behaviac
{
	// Token: 0x0200340D RID: 13325
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node9 : Condition
	{
		// Token: 0x0601506C RID: 86124 RVA: 0x00655ADC File Offset: 0x00653EDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
