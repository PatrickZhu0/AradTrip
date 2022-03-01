using System;

namespace behaviac
{
	// Token: 0x02003704 RID: 14084
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node18 : Assignment
	{
		// Token: 0x06015618 RID: 87576 RVA: 0x0067330C File Offset: 0x0067170C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int lastResult = ((BTAgent)pAgent).lastResult;
			((BTAgent)pAgent).compare = lastResult;
			return result;
		}
	}
}
