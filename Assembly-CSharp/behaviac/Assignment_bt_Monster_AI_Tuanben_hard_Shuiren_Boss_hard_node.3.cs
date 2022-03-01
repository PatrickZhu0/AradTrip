using System;

namespace behaviac
{
	// Token: 0x02003D7B RID: 15739
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node40 : Assignment
	{
		// Token: 0x0601628C RID: 90764 RVA: 0x006B2D24 File Offset: 0x006B1124
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
