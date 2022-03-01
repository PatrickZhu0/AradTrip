using System;

namespace behaviac
{
	// Token: 0x02003B91 RID: 15249
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node48 : Assignment
	{
		// Token: 0x06015ED3 RID: 89811 RVA: 0x006A01FC File Offset: 0x0069E5FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
