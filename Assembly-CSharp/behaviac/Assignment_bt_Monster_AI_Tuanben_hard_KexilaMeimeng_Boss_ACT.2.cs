using System;

namespace behaviac
{
	// Token: 0x02003C19 RID: 15385
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node32 : Assignment
	{
		// Token: 0x06015FDE RID: 90078 RVA: 0x006A501C File Offset: 0x006A341C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
