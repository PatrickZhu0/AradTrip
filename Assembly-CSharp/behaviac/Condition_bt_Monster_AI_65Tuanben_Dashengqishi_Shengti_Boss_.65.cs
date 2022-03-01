using System;

namespace behaviac
{
	// Token: 0x02002E3E RID: 11838
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node31 : Condition
	{
		// Token: 0x0601455A RID: 83290 RVA: 0x0061AC3C File Offset: 0x0061903C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Action_GetAlivePlayerNum();
			int num2 = 2;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
