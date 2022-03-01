using System;

namespace behaviac
{
	// Token: 0x02003B1B RID: 15131
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_node31 : Assignment
	{
		// Token: 0x06015DEF RID: 89583 RVA: 0x0069BD44 File Offset: 0x0069A144
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
