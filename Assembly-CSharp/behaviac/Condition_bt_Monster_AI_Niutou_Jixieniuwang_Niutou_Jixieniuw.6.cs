using System;

namespace behaviac
{
	// Token: 0x02003705 RID: 14085
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node20 : Condition
	{
		// Token: 0x0601561A RID: 87578 RVA: 0x0067333C File Offset: 0x0067173C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int lastResult = ((BTAgent)pAgent).lastResult;
			int num = 0;
			bool flag = lastResult > num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
