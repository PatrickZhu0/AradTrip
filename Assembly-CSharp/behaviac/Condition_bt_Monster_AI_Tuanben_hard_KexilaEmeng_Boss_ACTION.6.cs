using System;

namespace behaviac
{
	// Token: 0x02003B93 RID: 15251
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node77 : Condition
	{
		// Token: 0x06015ED7 RID: 89815 RVA: 0x006A0268 File Offset: 0x0069E668
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
