using System;

namespace behaviac
{
	// Token: 0x02002D6C RID: 11628
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node85 : Condition
	{
		// Token: 0x060143BB RID: 82875 RVA: 0x00614094 File Offset: 0x00612494
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HavePlayerUseAwakeSkill();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
