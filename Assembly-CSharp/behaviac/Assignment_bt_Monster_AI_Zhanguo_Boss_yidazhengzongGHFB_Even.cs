using System;

namespace behaviac
{
	// Token: 0x02003E75 RID: 15989
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguo_Boss_yidazhengzongGHFB_Event_node5 : Assignment
	{
		// Token: 0x0601646D RID: 91245 RVA: 0x006BC558 File Offset: 0x006BA958
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
