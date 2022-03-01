using System;

namespace behaviac
{
	// Token: 0x02003B2B RID: 15147
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_node42 : Assignment
	{
		// Token: 0x06015E0F RID: 89615 RVA: 0x0069C2E4 File Offset: 0x0069A6E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 5;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
