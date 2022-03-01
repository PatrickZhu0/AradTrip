using System;

namespace behaviac
{
	// Token: 0x02003B27 RID: 15143
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_node41 : Assignment
	{
		// Token: 0x06015E07 RID: 89607 RVA: 0x0069C17C File Offset: 0x0069A57C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 4;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
