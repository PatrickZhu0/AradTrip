using System;

namespace behaviac
{
	// Token: 0x02003B1F RID: 15135
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_node39 : Assignment
	{
		// Token: 0x06015DF7 RID: 89591 RVA: 0x0069BEAC File Offset: 0x0069A2AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
