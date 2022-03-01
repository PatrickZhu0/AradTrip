using System;

namespace behaviac
{
	// Token: 0x02002DA5 RID: 11685
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node85 : Condition
	{
		// Token: 0x0601442C RID: 82988 RVA: 0x00615FE0 File Offset: 0x006143E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HavePlayerUseAwakeSkill();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
