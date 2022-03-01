using System;

namespace behaviac
{
	// Token: 0x02003C3A RID: 15418
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node32 : Assignment
	{
		// Token: 0x0601601F RID: 90143 RVA: 0x006A6918 File Offset: 0x006A4D18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
