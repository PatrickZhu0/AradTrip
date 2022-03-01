using System;

namespace behaviac
{
	// Token: 0x02002ED3 RID: 11987
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node85 : Condition
	{
		// Token: 0x06014681 RID: 83585 RVA: 0x00622AA0 File Offset: 0x00620EA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HavePlayerUseAwakeSkill();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
