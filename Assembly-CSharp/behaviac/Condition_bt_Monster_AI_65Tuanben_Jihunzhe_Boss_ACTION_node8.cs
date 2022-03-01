using System;

namespace behaviac
{
	// Token: 0x02002F09 RID: 12041
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node85 : Condition
	{
		// Token: 0x060146EA RID: 83690 RVA: 0x006256E0 File Offset: 0x00623AE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HavePlayerUseAwakeSkill();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
