using System;

namespace behaviac
{
	// Token: 0x02003B8E RID: 15246
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node45 : Condition
	{
		// Token: 0x06015ECD RID: 89805 RVA: 0x006A00D4 File Offset: 0x0069E4D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
