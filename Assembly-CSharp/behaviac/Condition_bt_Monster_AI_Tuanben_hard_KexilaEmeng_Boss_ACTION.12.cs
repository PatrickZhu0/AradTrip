using System;

namespace behaviac
{
	// Token: 0x02003B9C RID: 15260
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node75 : Condition
	{
		// Token: 0x06015EE9 RID: 89833 RVA: 0x006A0578 File Offset: 0x0069E978
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
