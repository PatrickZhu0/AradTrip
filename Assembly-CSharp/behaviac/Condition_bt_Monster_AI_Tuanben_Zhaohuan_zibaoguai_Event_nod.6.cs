using System;

namespace behaviac
{
	// Token: 0x02003B84 RID: 15236
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node3 : Condition
	{
		// Token: 0x06015EBB RID: 89787 RVA: 0x0069FA8C File Offset: 0x0069DE8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetMonsterCount();
			int num2 = 0;
			bool flag = num > num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
