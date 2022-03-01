using System;

namespace behaviac
{
	// Token: 0x020037EF RID: 14319
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node1 : Assignment
	{
		// Token: 0x060157D5 RID: 88021 RVA: 0x0067C6C0 File Offset: 0x0067AAC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
