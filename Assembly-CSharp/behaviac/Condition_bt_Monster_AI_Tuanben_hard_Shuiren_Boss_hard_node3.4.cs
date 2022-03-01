using System;

namespace behaviac
{
	// Token: 0x02003D7C RID: 15740
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node34 : Condition
	{
		// Token: 0x0601628E RID: 90766 RVA: 0x006B2D4C File Offset: 0x006B114C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 3;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
